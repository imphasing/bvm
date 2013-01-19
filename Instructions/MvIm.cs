using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class MvIm : IOpcode
    {
        private int toLoad;
        private RegisterName destination;

        public MvIm(int toLoad, RegisterName destination)
        {
            this.toLoad = toLoad;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            state.registers[destination] = toLoad;
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new MvIm(toLoad, destination);
        }
    }
}
