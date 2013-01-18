using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Load : IOpcode
    {
        private IType toLoad;
        private IType destination;

        public Load(IType toLoad, IType destination)
        {
            this.toLoad = toLoad;
            this.destination = destination;
        }

        public void Execute(VmState state)
        {
            toLoad = toLoad.RetrieveReference(state);
            destination.AssignLocation(state, toLoad);
            state.registers.programCounter.value++;
        }

        public IType Copy()
        {
            return new Load(toLoad.Copy(), (VmInteger) destination.Copy());
        }
    }
}
