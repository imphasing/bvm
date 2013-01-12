using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VmThing.Types
{
    public class Integer : IType
    {
        public int value;

        public Integer(int value)
        {
            this.value = value;
        }
    }
}
