using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public interface IInstruction : IType
    {
        void Execute(VmState state);
    }
}
