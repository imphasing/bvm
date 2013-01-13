using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Ret : IInstruction
    {
        public void Execute(VmState state)
        {
            var previous = state.stack.Peek();
            var returnValue = state.registers.register3;

            state.stack.Pop();
            state.registers = previous.previousState;
            state.registers.register3 = returnValue;
            state.registers.programCounter.value++;
        }
    }
}
