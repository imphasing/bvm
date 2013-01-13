using System;
using System.Collections.Generic;
using System.Linq;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    public static class Program
    {
        static void Main()
        {
            var instructions = new List<IInstruction>();

            instructions.Add(new Load(new VmInteger(1), new VmInteger(1)));
            instructions.Add(new Load(new VmInteger(2), new VmInteger(2)));
            instructions.Add(new Call(new VmInteger(3)));
            instructions.Add(new Load(new VmInteger(10), new VmInteger(1)));
            instructions.Add(new Load(new VmInteger(20), new VmInteger(2)));
            instructions.Add(new Add());
            instructions.Add(new Ret());



            var vm = new Vm(instructions);
            var result = vm.Run();
        }
    }
}
