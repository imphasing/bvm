using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmThing.Types
{
    public class VmMemoryRef : IType
    {
        public int value;

        public VmMemoryRef(int value)
        {
            this.value = this.value;
        }

        public IType Copy()
        {
            return new VmMemoryRef(value);
        }
    }
}
