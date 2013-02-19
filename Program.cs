using System;
using System.Collections.Generic;
using bvm.Parser;
using bvm.Instructions;

namespace bvm
{
    public static class Program
    {
        static void Main()
       {
            var instructions = new List<IInstruction>();

            // address #0
            instructions.Add(new MvIm(10, RegisterName.R1));
            instructions.Add(new MvIm(20, RegisterName.R2));
            instructions.Add(new Add(RegisterName.R1, RegisterName.R2, RegisterName.R3));

           
            instructions.Add(new Push(RegisterName.R3));
            instructions.Add(new PushIm(15));
            instructions.Add(new Call(7 * 4));
            instructions.Add(new Ret());

            // address #9
            instructions.Add(new Push(RegisterName.R1));
            instructions.Add(new Push(RegisterName.R2));
            instructions.Add(new Push(RegisterName.R3));
            instructions.Add(new MvIm(63, RegisterName.R3));
            instructions.Add(new LoadOff(RegisterName.FP, -4, RegisterName.R1));
            instructions.Add(new LoadOff(RegisterName.FP, -5, RegisterName.R2));
            instructions.Add(new Add(RegisterName.R1, RegisterName.R2, RegisterName.RET));
            instructions.Add(new Pop(RegisterName.R3));
            instructions.Add(new Pop(RegisterName.R2));
            instructions.Add(new Pop(RegisterName.R1));
            instructions.Add(new Ret());


            var vm = new Vm(instructions);
            var result = vm.Run();
        }
    }
}
