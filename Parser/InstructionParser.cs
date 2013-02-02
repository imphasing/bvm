using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Instructions;

namespace VmThing.Parser
{

    /*
     * opcodes are of this format:
     * 32 bits
     * ------|---|----------------------|
     *   |     |           |
     * opcode type      goodies
     *
     * type and goodies are as follows:
     * 
     * type:  goodies:
     *  0     |r1|r2|r3|0s|
     *  1     |r1|17 bit val|r2|
     *  
     *  2     reserved
     *  3     |20 bits|r1|
     *  
     *  4     reserved
     *  5     |23 bits|
     *  
     *  6     reserved
     *  7     reserved
     *  
     * opcodes:
     * 
     * 0: add
     * 1: subtract
     * 2: multiply
     * 3: divide 
     * 4: shift right
     * 5: shift left
     * 6: pop
     * 7: push
     * 8: move
     * 9: call
     * 10: load
     * 11: return
     * 12: store
     * 
     *  
     */

    public static class InstructionParser
    {
        public static IInstruction Decode(uint binary)
        {
            uint opcode = binary >> 26;
            uint type = (binary >> 23) & 7;
            uint goodies = (binary << 9) >> 9;

            return ParseType(opcode, type, goodies);
        }

        public static IInstruction ParseType(uint opcode, uint type, uint goodies)
        {
            switch (type)
            {
                case 0:
                    return ParseThreeRegister(opcode, goodies);
                case 1:
                    return ParseRegisterBlockRegister(opcode, goodies);
                case 3:
                    return ParseBlockAndRegister(opcode, goodies);
                case 5:
                    return ParseBlock(opcode, goodies);
                default:
                    throw new Exception("Unknown type code: " + type);
            }
        }

        public static IInstruction ParseThreeRegister(uint opcode, uint goodies)
        {
            var register1 = (goodies >> 20) & 7;
            var register2 = (goodies >> 17) & 7;
            var register3 = (goodies >> 14) & 7;

            switch (opcode)
            {
                case 0:
                    return new Add((RegisterName) register1, (RegisterName) register2, (RegisterName) register3);
                case 1:
                    return new Sub((RegisterName) register1, (RegisterName) register2, (RegisterName) register3);
                case 2:
                    return new Mul((RegisterName) register1, (RegisterName) register2, (RegisterName) register3);
                case 3:
                    return new Div((RegisterName) register1, (RegisterName) register2, (RegisterName) register3);
                case 4:
                    return new Shr((RegisterName) register1, (RegisterName) register2, (RegisterName) register3);
                case 5:
                    return new Shl((RegisterName) register1, (RegisterName) register2, (RegisterName) register3);
                case 6:
                    return new Pop((RegisterName) register1);
                case 7:
                    return new Push((RegisterName) register1);
                case 8:
                    // one ignored param
                    return new Mv((RegisterName) register1, (RegisterName) register2);
                default:
                    throw new Exception("Unknown upcode for 3 register instruction: " + opcode);
            }
        }

        public static IInstruction ParseBlockAndRegister(uint opcode, uint goodies)
        {
            // shift right to remove register arg, and with 20 set bits
            var value = (goodies >> 3) & 1048575;
            var register1 = goodies & 7;

            switch (opcode)
            {
                case 8:
                    return new MvIm(value, (RegisterName) register1);
                case 10:
                    return new Load(value, (RegisterName) register1);
                case 12:
                    return new Store(value, (RegisterName) register1);
                default:
                    throw new Exception("Unknown opcode for 3 register instruction: " + opcode);
            }
        }

        public static IInstruction ParseRegisterBlockRegister(uint opcode, uint goodies)
        {
            var register1 = goodies >> 20;
            var value = ((goodies >> 3) << 6) >> 6;
            var register2 = (goodies << 29) >> 29;

            switch (opcode)
            {
                case 10:
                    var bytes = BitConverter.GetBytes(value);
                    return new LoadOff((RegisterName) register1, BitConverter.ToInt16(bytes, 0), (RegisterName) register2);
                default:
                    throw new Exception("Unknown opcode for register-block-register type: " + opcode);
            }
        }

        public static IInstruction ParseBlock(uint opcode, uint goodies)
        {
            switch (opcode)
            {
                case 7:
                    return new PushIm(goodies & 1048575);
                case 9:
                    return new Call(goodies & 1048575);
                case 11:
                    // param ignored
                    return new Ret(goodies);
                default:
                    throw new Exception("Unknown opcode for register-block-register type: " + opcode);
            }
        }
    }
}
