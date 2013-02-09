
namespace bvm.Instructions
{
    public class Store : IInstruction
    {
        private uint destination;
        private RegisterName source;

        public Store(uint destination, RegisterName source)
        {
            this.source = source;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            var bytes = state.registers.GetBytes(source);
            state.memory[destination] = bytes[0];
            state.memory[destination + 1] = bytes[1];
            state.memory[destination + 2] = bytes[2];
            state.memory[destination + 3] = bytes[3];

            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Store(destination, source);
        }

        public uint ToBinary()
        {
            uint opcode = 12;
            uint type = 3;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= (destination << 3);
            binary |= (uint) source;

            return binary;
        }
    }
}
