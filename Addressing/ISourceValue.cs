using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bvm.Addressing
{
    public interface ISourceValue
    {
        byte[] Resolve(VmState state, int length, object source);
    }
}
