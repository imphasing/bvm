using System;

namespace VmThing.Instructions
{
    public class Pop : IInstruction
    {
        private RegisterName destination;

        public Pop(RegisterName destination, RegisterName ignored = 0, RegisterName ignored2 = 0)
        {
            // we re-use the 3 register format and having 2 ignored params makes the parser easier.

            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[RegisterName.SP] -= 4;
            var value = BitConverter.ToUInt32(state.memory, (int) state.registers[RegisterName.SP]);
            state.registers[destination] = value;

            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Pop(destination);
        }

        public uint ToBinary()
        {
            uint opcode = 6;
            uint type = 0;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint) destination << 20);

            return binary;
        }
    }
}
