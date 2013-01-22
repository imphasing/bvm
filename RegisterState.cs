using System;
using System.Collections.Generic;

namespace VmThing
{
    public class RegisterState
    {
        public Dictionary<RegisterName, uint> registers;

        public uint this[RegisterName register]
        {
            get { return registers[register]; }
            set { registers[register] = value; }
        }

        public RegisterState()
        {   
            this.registers = new Dictionary<RegisterName, uint>();
            foreach (var i in Enum.GetValues(typeof(RegisterName)))
            {
                registers[i.As<RegisterName>()] = 0;
            }
        }

        public byte[] GetBytes(RegisterName name)
        {
            return BitConverter.GetBytes(registers[name]);
        }

        public RegisterState Clone()
        {
            var state = new RegisterState();
            
            foreach (var k in registers)
            {
                state.registers[k.Key] = k.Value;
            }

            return state;
        }
    }
}
