using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmThing.Types
{
    public class VmMemoryRef : IType
    {
        public uint value;

        public VmMemoryRef(uint value)
        {
            this.value = this.value;
        }

        public IType Copy()
        {
            return new VmMemoryRef(value);
        }
    }
}
