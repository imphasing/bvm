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

            this.registers = new RegisterState(null, null, null, new VmInteger(instructionCount), new VmInteger(instructionCount), new VmInteger(0));
            

            // bootstrap main return address for final return
            new Load(new VmInteger(instructionCount), new VmInteger(1)).Execute(this);
            new Push().Execute(this);
            new Load(new VmInteger(instructionCount), new VmInteger(1)).Execute(this);
            new Push().Execute(this);
            new Load(new VmInteger(int.MaxValue - 1), new VmInteger(1)).Execute(this);
            new Push().Execute(this);
            this.registers.programCounter = new VmInteger(0);
        }
    }
}
