using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Store : IOpcode
    {
        private RegisterName source;
        private VmMemoryRef destination;

        public Store(RegisterName source, VmMemoryRef destination)
        {
            this.source = source;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            var bytes = state.registers.GetBytes(source);
            state.memory[destination.value] = bytes[0];
            state.memory[destination.value + 1] = bytes[1];
            state.memory[destination.value + 2] = bytes[2];
            state.memory[destination.value + 3] = bytes[3];

            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new Store(source, destination);
        }
    }
}
