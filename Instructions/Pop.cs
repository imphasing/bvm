using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Pop : IOpcode
    {
        private RegisterName destination;

        public Pop(RegisterName destination)
        {
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[RegisterName.SP] -= 4;
            var value = BitConverter.ToUInt32(state.memory, state.registers[RegisterName.SP].As<int>());
            state.registers[destination] = value;

            state.registers[RegisterName.PC] += 1;
        }

        public IType Copy()
        {
            return new Pop(destination);
        }
    }
}
