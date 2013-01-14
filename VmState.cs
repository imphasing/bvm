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
        public RegisterState registers;
        public List<IType> memory;
        public int instructionCount;

        public VmState(List<IInstruction> instructions)
        {
            this.instructionCount = instructions.Count;

            // program size + 1 million locals/args
            this.memory = new List<IType>(instructions.Count + 1000000);
            this.memory.AddRange(Enumerable.Repeat((IType) null, 1000000));
            
            for (int i = 0; i < instructions.Count; i++)
            {
                this.memory[i] = instructions[i];
            }

            // index of first non-code location, the frame start, and the next item, the first local/arg space
            var frameStart =  instructions.Count;

            this.registers = new RegisterState(null, null, null, new VmInteger(frameStart), new VmInteger(frameStart), new VmInteger(0));
        }
    }
}
