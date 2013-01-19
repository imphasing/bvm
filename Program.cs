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
                load #10 R1
                load #20 R2
                add R1 R2 R3
                push R3
                push #10
                call num
                ret

                num:
                push R1
                push R2
                load $(fp - 1) R1
                load $(fp - 2) R2
                add
                pop R2
                pop R1
                ret
             */
            var instructions = new List<IOpcode>();

            // address #0
            instructions.Add(new MvIm(10, RegisterName.R1));
            instructions.Add(new MvIm(20, RegisterName.R2));
            instructions.Add(new Add(RegisterName.R1, RegisterName.R2, RegisterName.R3));

           
            instructions.Add(new Push(RegisterName.R3));
            instructions.Add(new MvIm(10, RegisterName.R4));
            instructions.Add(new Push(RegisterName.R4));
            instructions.Add(new Call(8));
            instructions.Add(new Ret());

            // address #9
            instructions.Add(new Push(RegisterName.R1));
            instructions.Add(new Push(RegisterName.R2));
            instructions.Add(new LoadExp(s => s.registers[RegisterName.FP] - 4, RegisterName.R1));
            instructions.Add(new LoadExp(s => s.registers[RegisterName.FP] - 8, RegisterName.R2));
            instructions.Add(new Add(RegisterName.R1, RegisterName.R2, RegisterName.RET));
            instructions.Add(new Pop(RegisterName.R2));
            instructions.Add(new Pop(RegisterName.R1));
            instructions.Add(new Ret());


            var vm = new Vm(instructions);
            var result = vm.Run();
        }
    }
}
