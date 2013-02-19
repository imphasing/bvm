using System;

namespace bvm.Addressing
{
    public class MemoryDestination : IDestinationValue
    {
        void IDestinationValue.Resolve(VmState state, byte[] value, object destination)
        {
            Resolve(state, value, (int) destination);
        }

        private void Resolve(VmState state, byte[] value, int destination)
        {
            foreach (var b in value)
            {
                state.memory[destination++] = b;
            }
        }
    }
}
