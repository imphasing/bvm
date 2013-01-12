using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Add : IInstruction
    {
        public void Execute(VmState state)
        {
            var arg1 = (Integer) state.stack.Pop();
            var arg2 = (Integer) state.stack.Pop();

            var result = new Integer(arg1.value + arg2.value);
            state.stack.Push(result);
            state.programCounter++;
        }
    }
}
