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
            var register1 = state.register1 == null ? null : state.register1.Copy();
            var register2 = state.register2 == null ? null : state.register2.Copy();
            var register3 = state.register3 == null ? null : state.register3.Copy();

            var stackPointer = state.stackPointer == null ? null : state.stackPointer.Copy();
            var framePointer = state.framePointer == null ? null : state.framePointer.Copy();
            var programCounter = state.programCounter == null ? null : state.programCounter.Copy();

            return new RegisterState(register1, register2, register3, (VmInteger) stackPointer, (VmInteger) framePointer, (VmInteger) programCounter);
        }


        public IType register1;
        public IType register2;
        public IType register3;

        public VmInteger stackPointer;
        public VmInteger framePointer;
        public VmInteger programCounter;

        public RegisterState(IType register1, IType register2, IType register3,  VmInteger stackPointer, VmInteger framePointer, VmInteger programCounter)
        {
            this.register1 = register1;
            this.register2 = register2;
            this.register3 = register3;

            this.stackPointer = stackPointer;
            this.framePointer = framePointer;
            this.programCounter = programCounter;
        }
    }
}
