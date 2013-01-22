using System;

namespace VmThing.Instructions
{
    public class PushIm : IInstruction
    {
        private uint toPush;

        public PushIm(uint toPush)
        {
            this.toPush = toPush;
        }


        public void Execute(VmState state)
        {
            var bytes = BitConverter.GetBytes(toPush);
            state.memory[state.registers[RegisterName.SP]] = bytes[0];
            state.memory[state.registers[RegisterName.SP] + 1] = bytes[1];
            state.memory[state.registers[RegisterName.SP] + 2] = bytes[2];
            state.memory[state.registers[RegisterName.SP] + 3] = bytes[3];

            state.registers[RegisterName.SP] += 4;
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new PushIm(toPush);
        }

        public uint ToBinary()
        {
            uint opcode = 7;
            uint type = 5;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= toPush;

            return binary;
        }
    }
}
