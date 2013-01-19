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
            state.registers[RegisterName.SP] -= 4;
            var oldPc = BitConverter.ToInt32(state.memory, state.registers[RegisterName.SP]);
            state.registers[RegisterName.SP] -= 4;
            var oldFrame = BitConverter.ToInt32(state.memory, state.registers[RegisterName.SP]);
            state.registers[RegisterName.SP] -= 4;
            var oldStack = BitConverter.ToInt32(state.memory, state.registers[RegisterName.SP]);

            state.registers[RegisterName.SP] = oldStack;
            state.registers[RegisterName.FP] = oldFrame;
            state.registers[RegisterName.PC] = oldPc;

            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new Ret();
        }
    }
}
