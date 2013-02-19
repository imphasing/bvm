using System;
using System.Linq;

namespace bvm.Addressing
{
    public class MemorySource : ISourceValue
    {
        byte[] ISourceValue.Resolve(VmState state, int length, object source)
        {
            return Resolve(state, length, (int) source);
        }

        private byte[] Resolve(VmState state, int length, int source)
        {
            var bytes = new byte[length];
            Array.Copy(state.memory, bytes, length);

            return bytes;
        }
    }
}
