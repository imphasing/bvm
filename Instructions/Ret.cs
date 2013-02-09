using System;

namespace bvm.Instructions
{
    public class Ret : IInstruction
    {
        public Ret(uint ignored = 0)
        {
            
        }

        public void Execute(VmState state)
        {
            var oldPc = BitConverter.ToUInt32(state.memory, (int) state.registers[RegisterName.FP] - 4);
            var oldFrame = BitConverter.ToUInt32(state.memory, (int) state.registers[RegisterName.FP] - 8);
            var oldStack = BitConverter.ToUInt32(state.memory, (int) state.registers[RegisterName.FP] - 12);

            state.registers[RegisterName.SP] = oldStack;
            state.registers[RegisterName.FP] = oldFrame;
            state.registers[RegisterName.PC] = oldPc;

            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new Ret();
        }

        public uint ToBinary()
        {
            uint opcode = 11;
            uint type = 5;
            uint binary = 0;

            binary |= (opcode << 26);
            binary |= (type << 23);

            return binary;
        }
    }
}
