using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmThing.Types
{
    public class VmString : IType
    {
        public string value;

        public VmString(string value)
        {
            this.value = value;
        }

        public IType Copy()
        {
            return new VmString(value);
        }
    }
}
