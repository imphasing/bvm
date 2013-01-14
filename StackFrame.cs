using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing
{
    public class StackFrame
    {
        public RegisterState previousState;

        public StackFrame(RegisterState previousState)
        {
            this.previousState = previousState;
        }
    }
}
