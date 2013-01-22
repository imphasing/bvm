
namespace VmThing.Instructions
{
    public class Push : IInstruction
    {
        private RegisterName toPush;

        public Push(RegisterName toPush, RegisterName ignored = 0, RegisterName ignored2 = 0)
        {
            // we re-use the 3 register format and having 2 ignored params makes the parser easier.

            this.toPush = toPush;
        }


        public void Execute(VmState state)
        {
            var bytes = state.registers.GetBytes(toPush);
            state.memory[state.registers[RegisterName.SP]] = bytes[0];
            state.memory[state.registers[RegisterName.SP] + 1] = bytes[1];
            state.memory[state.registers[RegisterName.SP] + 2] = bytes[2];
            state.memory[state.registers[RegisterName.SP] + 3] = bytes[3];

            state.registers[RegisterName.SP] += 4;
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Push(toPush);
        }

        public uint ToBinary()
        {
            uint opcode = 7;
            uint type = 0;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= ((uint) toPush << 20);

            return binary;
        }
    }
}
