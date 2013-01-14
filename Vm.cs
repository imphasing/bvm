using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    public class Vm
    {
        public VmState state;

        public Vm(List<IInstruction> instructions)
        {
            this.state = new VmState(instructions);
        }

        public IType Run()
        {
            // int.MaxValue is the magical end of computation address
            while (state.registers.programCounter.value != int.MaxValue)
            {
                var nextInstruction = (IInstruction) state.memory[state.registers.programCounter.value];
                nextInstruction.Execute(state);
            }

            return state.registers.register3;
        }
    }
}
