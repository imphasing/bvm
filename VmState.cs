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
        public List<IInstruction> instructions;
        public Stack<StackFrame> stack;
        public RegisterState registers;
        

        public VmState(int programCounter, List<IInstruction> instructions)
        {
            this.registers = new RegisterState(null, null, null, new VmInteger(programCounter));

            this.stack = new Stack<StackFrame>();
            stack.Push(new StackFrame(new Stack<IType>(), registers));

            this.instructions = instructions;
        }
    }
}
