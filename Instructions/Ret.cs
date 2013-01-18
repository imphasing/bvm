using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Ret : IOpcode
    {
        public void Execute(VmState state)
        {
            state.registers.ApplyAs<VmInteger>(x => x.value--, RegisterName.SP);
            var oldPc = state.memory[state.registers.GetAs<VmInteger>(RegisterName.SP).value];

            state.registers.ApplyAs<VmInteger>(x => x.value--, RegisterName.SP);
            var oldFrame = state.memory[state.registers.GetAs<VmInteger>(RegisterName.SP).value];

            state.registers.ApplyAs<VmInteger>(x => x.value--, RegisterName.SP);
            var oldStack = state.memory[state.registers.GetAs<VmInteger>(RegisterName.SP).value];

            state.registers.Set(RegisterName.SP, oldStack.As<VmInteger>());
            state.registers.Set(RegisterName.FP, oldFrame.As<VmInteger>());

            oldPc.As<VmInteger>().value++;
            state.registers.Set(RegisterName.PC,  oldPc.As<VmInteger>());
        }

        public IType Copy()
        {
            return new Ret();
        }
    }
}
