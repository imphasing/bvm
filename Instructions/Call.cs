using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Call : IInstruction
    {
        private VmInteger location;

        public Call(VmInteger location)
        {
            this.location = location;
        }


        public void Execute(VmState state)
        {
            StackFrame next = new StackFrame(state.stack.Peek().locals, RegisterState.DeepClone(state.registers));

            state.stack.Push(next);
            state.registers.programCounter = location;
        }
    }
}
