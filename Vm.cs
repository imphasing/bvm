using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    class Vm
    {
        public VmState state;

        public Vm(List<IInstruction> instructions)
        {
            var stack = new Stack<IType>();
            var programCounter = 0;

            this.state = new VmState(stack, programCounter, instructions);
        }

        public IType Run()
        {
            while (state.programCounter < state.instructions.Count)
            {
                var nextInstruction = state.instructions[state.programCounter];
                nextInstruction.Execute(state);
            }

            return state.stack.Pop();
        }
    }
}
