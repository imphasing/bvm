using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Push : IOpcode
    {
        public void Execute(VmState state)
        {
            var toPush = state.registers.register1.RetrieveReference(state);

            state.memory[state.registers.stackPointer.value] = toPush;
            state.registers.stackPointer.value++;
            state.registers.programCounter.value++;
        }

        public IType Copy()
        {
            return new Push();
        }
    }
}
