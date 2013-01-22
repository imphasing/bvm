using System;
using System.Collections.Generic;
using VmThing.Instructions;
using VmThing.Parser;

namespace VmThing
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
            while (state.registers[RegisterName.PC] != uint.MaxValue)
            {
                var encoded = BitConverter.ToUInt32(state.memory, (int) state.registers[RegisterName.PC]);
                var instruction = InstructionParser.Decode(encoded);

                instruction.Execute(state);
            }

            return state.registers[RegisterName.RET];
        }
    }
}
