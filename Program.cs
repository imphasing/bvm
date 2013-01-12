using System;
using System.Collections.Generic;
using System.Linq;
using VmThing.Instructions;
using VmThing.Types;

namespace VmThing
{
    static class Program
    {
        static void Main()
        {
            var instructions = new List<IInstruction>();
            instructions.Add(new Push(new Integer(5)));
            instructions.Add(new Push(new Integer(10)));
            instructions.Add(new Add());
            instructions.Add(new Push(new Integer(20)));
            instructions.Add(new Add());

            var vm = new Vm(instructions);
            var result = vm.Run();
        }
    }
}
