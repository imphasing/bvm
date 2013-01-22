
namespace VmThing.Instructions
{
    public class Shl : IInstruction
    {
        private RegisterName target;
        private RegisterName source;
        private RegisterName result;

        public Shl(RegisterName target, RegisterName source, RegisterName result)
        {
            this.target = target;
            this.source = source;
            this.result = result;
        }


        public void Execute(VmState state)
        {
            state.registers[result] = state.registers[target] << (int) state.registers[source];
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Shl(target, source, result);
        }

        public uint ToBinary()
        {
            uint opcode = 5;
            uint type = 0;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint) target << 20);
            binary |= ((uint) source << 17);
            binary |= ((uint) result << 14);

            return binary;
        }
    }
}
