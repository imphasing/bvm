using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing
{
    public class StackFrame
    {
        public Stack<IType> locals;
        public RegisterState previousState;

        public StackFrame(Stack<IType> locals, RegisterState previousState)
        {
            this.previousState = previousState;
            this.locals = locals;
        }
    }
}
