
using System;

namespace bvm.Instructions
{
    public class StoreOff : IInstruction
    {
        private RegisterName destination;
        private short offset;
        private uint offsetUnsigned;
        private RegisterName source;

        public StoreOff(RegisterName source, short offset, RegisterName destination)
        {
            var bytes = new byte[4];
            var shortBytes = BitConverter.GetBytes(offset);

            for (int i = 0; i < shortBytes.Length; i++)
                bytes[i] = shortBytes[i];

            var bytesAsUnsigned = BitConverter.ToUInt32(bytes, 0);

            this.source = source;
            this.offset = offset;
            this.offsetUnsigned = bytesAsUnsigned;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            // offset is a signed short, who's max value is +/- 32767
            // by shifting left, we multiply by 4, which gives us aligned access only
            // but allows me to offset by up to +/- 131068
            int intOffset = offset;
            intOffset <<= 2;

            int location = (int) state.registers[destination] + intOffset;

            var bytes = state.registers.GetBytes(source);
            state.memory[location] = bytes[0];
            state.memory[location + 1] = bytes[1];
            state.memory[location + 2] = bytes[2];
            state.memory[location + 3] = bytes[3];

            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new StoreOff(source, offset, destination);
        }

        public uint ToBinary()
        {
            uint opcode = 12;
            uint type = 1;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint)source << 20);
            binary |= offsetUnsigned << 3;
            binary |= ((uint)destination);

            return binary;
        }
    }
}
