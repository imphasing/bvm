using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Call : IInstruction
    {
        private VmInteger location;

        public Call(VmInteger location)
        {
            this.location = location;
        }


        public void Execute(VmState state)
        {
            // push stack pointer, frame pointer, and program counter
            new Load(state.registers.stackPointer.Copy(), new VmInteger(1)).Execute(state);
            new Push().Execute(state);
            new Load(state.registers.framePointer.Copy(), new VmInteger(1)).Execute(state);
            new Push().Execute(state);
            new Load(state.registers.programCounter.Copy(), new VmInteger(1)).Execute(state);
            new Push().Execute(state);

            state.registers.framePointer = state.registers.stackPointer;
            state.registers.stackPointer = state.registers.framePointer;

            state.registers.programCounter.value = location.value;
        }

        public IType Copy()
        {
            return new Call((VmInteger) location.Copy());
        }
    }
}
