using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmThing.Types
{
    public class VmRegisterRef : IType
    {
        public int value;

        public VmRegisterRef(int value)
        {
            this.value = this.value;
        }

        public IType Copy()
        {
            return new VmRegisterRef(value);
        }
    }
}
