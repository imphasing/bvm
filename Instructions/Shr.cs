﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Shr : IOpcode
    {
        public VmInteger src;

        public Shr(VmInteger src)
        {
            this.src = src;
        }


        public void Execute(VmState state)
        {
            var arg1 = (VmInteger) state.registers.register1;
            arg1.value >>= src.value;

            state.registers.programCounter.value++;
        }

        public IType Copy()
        {
            return new Shr((VmInteger) src.Copy());
        }
    }
}
