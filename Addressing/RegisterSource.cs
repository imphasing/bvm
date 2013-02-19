
using System;

namespace bvm.Addressing
{
    public class RegisterSource : ISourceValue
    {
        byte[] ISourceValue.Resolve(VmState state, int length, object source)
        {
            return Resolve(state, length, (RegisterName)source);
        }

        private byte[] Resolve(VmState state, int length, RegisterName source)
        {
            var bytes = BitConverter.GetBytes(state.registers[source]);
            return bytes;
        }
    }
}
