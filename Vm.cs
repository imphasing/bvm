using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    public class Vm
    {
        public VmState state;

        public Vm(List<IInstruction> instructions)
        {
            var stack = new Stack<StackFrame>();
            stack.Push(new StackFrame(new Stack<IType>(), new RegisterState(null, null, null, new VmInteger(0))));
            this.state = new VmState(0, instructions);
        }

        public IType Run()
        {
            while (state.registers.programCounter.value < state.instructions.Count)
            {
                var nextInstruction = state.instructions[state.registers.programCounter.value];
                nextInstruction.Execute(state);
            }

            return state.registers.register3;
        }
    }
}
