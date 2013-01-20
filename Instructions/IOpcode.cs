using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing.Instructions
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
     *  2     |r1|r2|0s|
     *  3     |20 bit val|r1|
     *  
     *  4     |r1|0s|
     *  5     |23 bit val|
     *  
     *  6     |20 bit address|r1|
     *  7     reserved
     *  
     * opcodes:
     * 
     * 0: add
     * 2: subtract
     * 4: multiply
     * 6: divide
     * 8: shift right
     * 10: shift left
     * 12: pop
     * 13: push
     * 15: move
     * 17: call
     * 19: load
     * 21: return
     * 22: store
     * 
     * 
     * 
     *  
     */

    public interface IOpcode : IType
    {
        void Execute(VmState state);
        //uint ToBinary();
    }
}
