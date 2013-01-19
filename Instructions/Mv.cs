using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Mv : IOpcode
    {
        private RegisterName toLoad;
        private RegisterName destination;

        public Mv(RegisterName toLoad, RegisterName destination)
        {
            this.toLoad = toLoad;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[destination] = state.registers[toLoad];
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new Mv(toLoad, destination);
        }
    }
}
