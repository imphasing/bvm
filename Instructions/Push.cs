using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Push : IInstruction
    {
        public void Execute(VmState state)
        {
            var toPush = state.registers.register1;

            state.stack.Peek().locals.Push(toPush);
            state.registers.programCounter.value++;
        }
    }
}
