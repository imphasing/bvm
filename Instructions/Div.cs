
namespace VmThing.Instructions
{
    public class Div : IInstruction
    {
        private RegisterName arg1;
        private RegisterName arg2;
        private RegisterName result;

        public Div(RegisterName arg1, RegisterName arg2, RegisterName result)
        {
            this.result = result;
            this.arg2 = arg2;
            this.arg1 = arg1;
        }


        public void Execute(VmState state)
        {
            state.registers[result] = state.registers[arg1] / state.registers[arg2];
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Div(arg1, arg2, result);
        }

        public uint ToBinary()
        {
            uint opcode = 3;
            uint type = 0;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint) arg1 << 20);
            binary |= ((uint) arg2 << 17);
            binary |= ((uint) result << 14);

            return binary;
        }
    }
}
