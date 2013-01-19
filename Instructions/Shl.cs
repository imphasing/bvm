﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Shl : IOpcode
    {
        private RegisterName target;
        private RegisterName source;
        private RegisterName result;

        public Shl(RegisterName target, RegisterName source, RegisterName result)
        {
            this.target = target;
            this.source = source;
            this.result = result;
        }


        public void Execute(VmState state)
        {
            state.registers[result] = state.registers[target] << state.registers[source];
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new Shl(target, source, result);
        }
    }
}