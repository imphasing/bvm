using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public interface IOpcode : IType
    {
        void Execute(VmState state);
    }
}
