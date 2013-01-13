using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Add : IInstruction
    {
        public void Execute(VmState state)
        {
            var arg1 = (VmInteger) state.registers.register1;
            var arg2 = (VmInteger) state.registers.register2;

            var result = new VmInteger(arg1.value + arg2.value);
            state.registers.register3 = result;

            state.registers.programCounter.value++;
        }
    }
}
