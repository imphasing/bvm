
namespace bvm.Instructions
{
    public class MvIm : IInstruction
    {
        private uint toLoad;
        private RegisterName destination;

        public MvIm(uint toLoad, RegisterName destination)
        {
            this.toLoad = toLoad;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[destination] = toLoad;
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new MvIm(toLoad, destination);
        }

        public uint ToBinary()
        {
            uint opcode = 8;
            uint type = 3;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= (toLoad << 3);
            binary |= (uint) destination;

            return binary;
        }
    }
}
