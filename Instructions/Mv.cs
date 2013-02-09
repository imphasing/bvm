
namespace bvm.Instructions
{
    public class Mv : IInstruction
    {
        private RegisterName toLoad;
        private RegisterName destination;

        public Mv(RegisterName toLoad, RegisterName destination, RegisterName ignored = 0)
        {
            // we re-use the 3 register format and having 1 ignored param makes the parser easier.

            this.toLoad = toLoad;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[destination] = state.registers[toLoad];
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Mv(toLoad, destination);
        }

        public uint ToBinary()
        {
            uint opcode = 8;
            uint type = 0;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint) toLoad << 20);
            binary |= ((uint) destination << 17);

            return binary;
        }
    }
}
