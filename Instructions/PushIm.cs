using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class PushIm : IOpcode
    {
        private int toPush;

        public PushIm(int toPush)
        {
            this.toPush = toPush;
        }


        public void Execute(VmState state)
        {
            var bytes = BitConverter.GetBytes(toPush);
            state.memory[state.registers[RegisterName.SP]] = bytes[0];
            state.memory[state.registers[RegisterName.SP] + 1] = bytes[1];
            state.memory[state.registers[RegisterName.SP] + 2] = bytes[2];
            state.memory[state.registers[RegisterName.SP] + 3] = bytes[3];

            state.registers[RegisterName.SP] += 4;
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new PushIm(toPush);
        }
    }
}
