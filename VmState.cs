using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    public class VmState
    {
        public RegisterState registers;
        public byte[] memory;
        public List<IOpcode> instructions;

        public VmState(List<IOpcode> instructions, int memorySize)
        {
            this.instructions = instructions;
            this.registers = new RegisterState();

            this.memory = new byte[memorySize];
            Array.Clear(memory, 0, memory.Length);


            var instructionCount = instructions.Count;

            // bootstrap main return address for final return
            new PushIm(instructionCount).Execute(this);
            new PushIm(instructionCount).Execute(this);
            new PushIm(int.MaxValue - 1).Execute(this);

            this.registers[RegisterName.PC] = 0;
        }
    }
}
