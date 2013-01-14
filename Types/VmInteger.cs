using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmThing.Types
{
    public class VmInteger : IType
    {
        public int value;

        public VmInteger(int value)
        {
            this.value = value;
        }

        public IType Copy()
        {
            return new VmInteger(value);
        }
    }
}
