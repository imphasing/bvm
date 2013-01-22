using System;

namespace VmThing.Instructions
{
    public class LoadExp : IInstruction
    {
        private Func<VmState, uint> expression;
        private RegisterName destination;

        public LoadExp(Func<VmState, uint> expression, RegisterName destination)
        {
            this.expression = expression;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[destination] = state.memory[expression(state)];
            state.registers[RegisterName.PC] += 4;
        }

        public IInstruction Copy()
        {
            return new LoadExp(expression, destination);
        }

        public uint ToBinary()
        {
            return 0;
        }
    }
}
