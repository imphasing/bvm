using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Ret : IInstruction
    {
        public void Execute(VmState state)
        {
            var oldPc = state.memory[--state.registers.stackPointer.value];
            var oldFrame = state.memory[--state.registers.stackPointer.value];
            var oldStack = state.memory[--state.registers.stackPointer.value];

            state.registers.stackPointer = oldStack.As<VmInteger>();
            state.registers.framePointer = oldFrame.As<VmInteger>();

            oldPc.As<VmInteger>().value++;
            state.registers.programCounter = oldPc.As<VmInteger>();
        }

        public IType Copy()
        {
            return new Ret();
        }
    }
}
