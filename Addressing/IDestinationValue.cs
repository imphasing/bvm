using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bvm.Addressing
{
    public interface IDestinationValue
    {
        void Resolve(VmState state, byte[] value, object destination);
    }
}
