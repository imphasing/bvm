using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Load : IInstruction
    {
        private readonly IType toLoad;
        private readonly VmInteger register;

        public Load(IType toLoad, VmInteger register)
        {
            this.toLoad = toLoad;
            this.register = register;
        }

        public void Execute(VmState state)
        {
            switch (register.value)
            {
                case 1:
                    state.registers.register1 = toLoad;
                    break;
                case 2:
                    state.registers.register2 = toLoad;
                    break;
                case 3:
                    state.registers.register3 = toLoad;
                    break;
                case 4:
                    state.registers.programCounter = (VmInteger) toLoad;
                    break;
            }

            state.registers.programCounter.value++;
        }
    }
}
