using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class LoadExp : IOpcode
    {
        private Func<VmState, int> expression; 
        private RegisterName destination;

        public LoadExp(Func<VmState, int> expression, RegisterName destination)
        {
            this.expression = expression;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[destination] = state.memory[expression(state)];
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new LoadExp(expression, destination);
        }
    }
}
