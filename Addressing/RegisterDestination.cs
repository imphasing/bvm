
using System;

namespace bvm.Addressing
{
    public class RegisterDestination : IDestinationValue
    {
        void IDestinationValue.Resolve(VmState state, byte[] value, object destination)
        {
            Resolve(state, value, (RegisterName) destination);
        }

        private void Resolve(VmState state, byte[] value, RegisterName destination)
        {
            state.registers[destination] = BitConverter.ToUInt32(value, 0);
        }
    }
}
