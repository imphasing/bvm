using System;

namespace VmThing.Instructions
{
    public class Load : IInstruction
    {
        private uint source;
        private RegisterName destination;

        public Load(uint source, RegisterName destination)
        {
            this.source = source;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            var value = BitConverter.ToUInt32(state.memory, (int) source);
            state.registers[destination] = value;
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Load(source, destination);
        }

        public uint ToBinary()
        {
            uint opcode = 10;
            uint type = 3;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= (source << 3);
            binary |= (uint) destination;

            return binary;
        }
    }
}
