﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
{
    public class Pop : IInstruction
    {
        public void Execute(VmState state)
        {
            state.registers.register3 = state.stack.Peek().locals.Pop();
            state.registers.programCounter.value++;
        }
    }
}
