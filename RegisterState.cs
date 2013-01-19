using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing
{
    public class RegisterState
    {
        public Dictionary<RegisterName, int> registers;

        public int this[RegisterName register]
        {
            get { return registers[register]; }
            set { registers[register] = value; }
        }

        public RegisterState()
        {   
            this.registers = new Dictionary<RegisterName, int>();
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
