using System;
using System.Collections.Generic;
using bvm.Instructions;
using bvm.Parser;

namespace bvm
{
    public class Vm
    {
        public VmState state;

        public Vm(List<IInstruction> instructions)
        {
            this.state = new VmState(instructions, 1000000);
        }

        public uint Run()
        {
            // int.MaxValue is the magical end of computation address
            while (state.registers[RegisterName.PC] != int.MaxValue)
            {
                var encoded = BitConverter.ToUInt32(state.memory, (int) state.registers[RegisterName.PC]);
                var instruction = InstructionParser.Decode(encoded);

                instruction.Execute(state);
            }

            return state.registers[RegisterName.RET];
        }
    }
}
