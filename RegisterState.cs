using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing
{
    public class RegisterState
    {
        public static RegisterState DeepClone(RegisterState state)
        {
            return new RegisterState(state.register1, state.register2, state.register3, state.programCounter);
        }


        public IType register1;
        public IType register2;
        public IType register3;

        public VmInteger programCounter;

        public RegisterState(IType register1, IType register2, IType register3, VmInteger programCounter)
        {
            this.register1 = register1;
            this.register2 = register2;
            this.register3 = register3;

            this.programCounter = programCounter;
        }
    }
}
