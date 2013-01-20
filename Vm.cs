﻿using System;
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

        public Vm(List<IOpcode> instructions)
        {
            this.state = new VmState(instructions, 1000000);
        }

        public uint Run()
        {
            // int.MaxValue is the magical end of computation address
            while (state.registers[RegisterName.PC] != uint.MaxValue)
            {
                var instruction = state.instructions[state.registers[RegisterName.PC].As<int>()];
                instruction.Execute(state);
            }

            return state.registers[RegisterName.RET];
        }
    }
}
