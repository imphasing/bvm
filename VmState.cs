using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    public class VmState
    {
        public Stack<IType> stack;
        public int programCounter;
        public List<IInstruction> instructions;

        public VmState(Stack<IType> stack, int programCounter, List<IInstruction> instructions)
        {
            this.stack = stack;
            this.programCounter = programCounter;
            this.instructions = instructions;
        }
    }
}
