﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Load : IOpcode
    {
        private VmMemoryRef source;
        private RegisterName destination;

        public Load(VmMemoryRef source, RegisterName destination)
        {
            this.source = source;
            this.destination = destination;
        }


        public void Execute(VmState state)
        {
            var value = BitConverter.ToInt32(state.memory, source.value);
            state.registers[destination] = value;
            state.registers[RegisterName.PC] += 4;
        }

        public IType Copy()
        {
            return new Load(source, destination);
        }
    }
}
