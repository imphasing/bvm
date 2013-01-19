using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Call : IOpcode
    {
        private int location;

        public Call(int location)
        {
            this.location = location;
        }


        public void Execute(VmState state)
        {
            // push stack pointer, frame pointer, and program counter
            new Push(RegisterName.SP).Execute(state);
            new Push(RegisterName.FP).Execute(state);
            new Push(RegisterName.PC).Execute(state);

            state.registers[RegisterName.FP] = state.registers[RegisterName.SP];
            state.registers[RegisterName.SP] = state.registers[RegisterName.FP];

            state.registers[RegisterName.PC] = location;
        }

        public IType Copy()
        {
            return new Call(location);
        }
    }
}
