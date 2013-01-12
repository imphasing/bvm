using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Push : IInstruction
    {
        private readonly IType toPush;

        public Push(IType type)
        {
            this.toPush = type;
        }

        public void Execute(VmState state)
        {
            state.stack.Push(toPush);
            state.programCounter++;
        }
    }
}
