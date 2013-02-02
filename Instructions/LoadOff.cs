using System;

namespace VmThing.Instructions
{
    public class LoadOff : IInstruction
    {
        private RegisterName source;
        private uint offsetUnsigned;
        private short offset;
        private RegisterName destination;

        public LoadOff(RegisterName source, short offset, RegisterName destination)
        {
            var bytes = new byte[4];
            var shortBytes = BitConverter.GetBytes(offset);

            for (int i = 0; i < shortBytes.Length; i++)
                bytes[i] = shortBytes[i];

            var bytesAsUnsigned = BitConverter.ToUInt32(bytes, 0);

            this.source = source;
            this.offsetUnsigned = bytesAsUnsigned;
            this.offset = offset;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            int location = (int) state.registers[source] + offset;

            var value = BitConverter.ToUInt32(state.memory, location);
            state.registers[destination] = value;
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new LoadOff(source, offset, destination);
        }

        public uint ToBinary()
        {
            uint opcode = 10;
            uint type = 1;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint) source << 20);
            binary |= ((uint) offsetUnsigned << 3);
            binary |= ((uint) destination);

            return binary;
        }
    }
}
