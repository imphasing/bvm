using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Pop : IOpcode
    {
        public void Execute(VmState state)
        {
            state.registers.register3 = state.memory[--state.registers.stackPointer.value];
            
            state.registers.programCounter.value++;
        }

        public IType Copy()
        {
            return new Pop();
        }
    }
}
