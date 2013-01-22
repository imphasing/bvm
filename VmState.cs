using System;
using System.Collections.Generic;
using VmThing.Instructions;

namespace VmThing
{
    public class VmState
    {
        public RegisterState registers;
        public byte[] memory;
        public List<IInstruction> instructions;

        public VmState(List<IInstruction> instructions, int memorySize)
        {
            this.instructions = instructions;
            this.registers = new RegisterState();

            this.memory = new byte[memorySize];
            Array.Clear(memory, 0, memory.Length);

            // load up instructions as binary in memory
            for (int i = 0, j = 0; i < instructions.Count; i++, j += 4)
            {
                var bytes = BitConverter.GetBytes(instructions[i].ToBinary());
                memory[j] = bytes[0];
                memory[j + 1] = bytes[1];
                memory[j + 2] = bytes[2];
                memory[j + 3] = bytes[3];
            }

            // set frame and stack pointers to the first non-instruction byte
            var instructionCount = (uint) instructions.Count;
            registers[RegisterName.SP] = instructionCount * 4; // 4 bytes lol
            registers[RegisterName.FP] = instructionCount * 4;

            // bootstrap main return address for final return
            new PushIm(instructionCount).Execute(this);
            new PushIm(instructionCount).Execute(this);
            new PushIm(uint.MaxValue - 1).Execute(this);
            registers[RegisterName.FP] = registers[RegisterName.SP];

            this.registers[RegisterName.PC] = 0;
        }
    }
}
