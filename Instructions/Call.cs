
namespace bvm.Instructions
{
    public class Call : IInstruction
    {
        private uint location;

        public Call(uint location)
        {
            this.location = location;
        }


        public void Execute(VmState state)
        {
            // push stack pointer, frame pointer, and program counter then reset PC
            var pc = state.registers[RegisterName.PC];
            new Push(RegisterName.SP).Execute(state);
            new Push(RegisterName.FP).Execute(state);
            new PushIm(pc).Execute(state);
            state.registers[RegisterName.PC] = pc;

            state.registers[RegisterName.FP] = state.registers[RegisterName.SP];
            state.registers[RegisterName.SP] = state.registers[RegisterName.FP];

            state.registers[RegisterName.PC] = location;
        }

        public IInstruction Copy()
        {
            return new Call(location);
        }

        public uint ToBinary()
        {
            uint opcode = 9;
            uint type = 5;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);
            binary |= location;

            return binary;
        }
    }
}
