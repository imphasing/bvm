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
            /* 
                load #10 r1
                load #20 r2
                add
                push r3
                push #10
                call num
                ret

                num:
                push r1
                push r2
                load (fp - 1) r1
                load (fp - 2) r2
                add
                pop r2
                pop r1
                ret
             */
            var instructions = new List<IInstruction>();

            // address #0
            instructions.Add(new Load(new VmInteger(10), new VmInteger(1)));
            instructions.Add(new Load(new VmInteger(20), new VmInteger(2)));
            instructions.Add(new Add());

            instructions.Add(new Load(new VmRegisterRef(3), new VmInteger(1)));
            instructions.Add(new Push());
            instructions.Add(new Load(new VmInteger(10), new VmInteger(1)));
            instructions.Add(new Push());

            instructions.Add(new Call(new VmInteger(9)));
            instructions.Add(new Ret());

            // address #9
            instructions.Add(new Push());
            instructions.Add(new Load(new VmRegisterRef(2), new VmRegisterRef(1)));
            instructions.Add(new Push());

            instructions.Add(new Load(new VmRegisterRef(5), new VmRegisterRef(1)));
            instructions.Add(new Load(new VmInteger(1), new VmRegisterRef(2)));
            instructions.Add(new Sub());






            // address 4
            instructions.Add(new Load(new VmInteger(10), new VmInteger(1)));
            instructions.Add(new Load(new VmInteger(20), new VmInteger(2)));
            instructions.Add(new Add());
            instructions.Add(new Ret());



            var vm = new Vm(instructions);
            var result = vm.Run();
        }
    }
}
