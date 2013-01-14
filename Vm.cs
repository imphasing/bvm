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
            // execute until we unwind indo coad
            while (state.registers.stackPointer.value >= state.instructionCount)
            {
                var nextInstruction = (IInstruction) state.memory[state.registers.programCounter.value];
                nextInstruction.Execute(state);
            }

            return state.registers.register3;
        }
    }
}
