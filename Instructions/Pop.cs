using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Pop : IInstruction
    {
        public void Execute(VmState state)
        {
            state.stack.Pop();
            state.programCounter++;
        }
    }
}
