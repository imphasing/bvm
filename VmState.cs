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
        public List<byte> memory;
        public List<IOpcode> instructions;

        public VmState(List<IOpcode> instructions, int memorySize)
        {
            this.instructions = instructions;
            this.registers = new RegisterState();

            this.memory = new List<byte>(memorySize);
            this.memory.AddRange(Enumerable.Repeat(0.As<byte>(), memorySize));

            var instructionCount = instructions.Count;

            // bootstrap main return address for final return
            new Load(new VmInteger(instructionCount), new VmInteger(1)).Execute(this);
            new Push().Execute(this);
            new Load(new VmInteger(instructionCount), new VmInteger(1)).Execute(this);
            new Push().Execute(this);
            new Load(new VmInteger(int.MaxValue - 1), new VmInteger(1)).Execute(this);
            new Push().Execute(this);
            this.registers.SetRegister(RegisterName.PC, new VmInteger(0));
            this.registers.SetRegister(RegisterName.r1, null);
        }
    }
}
