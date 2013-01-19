﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Div : IOpcode
    {
        private RegisterName arg1;
        private RegisterName arg2;
        private RegisterName result;

        public Div(RegisterName arg1, RegisterName arg2, RegisterName result)
        {
            this.result = result;
            this.arg2 = arg2;
            this.arg1 = arg1;
        }


        public void Execute(VmState state)
        {
            state.registers[result] = state.registers[arg1] / state.registers[arg2];
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new Div(arg1, arg2, result);
        }
    }
}