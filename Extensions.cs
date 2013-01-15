using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VmThing.Types;

namespace VmThing
{
    public static class Extensions
    {
        public static T As<T>(this object obj)
        {
            return (T) obj;
        }

        public static IType RetrieveReference(this IType location, VmState state)
        {
            if (location is VmRegisterRef)
            {
                return state.ReferenceRegister(location.As<VmRegisterRef>().value);
            }
            else if (location is VmMemoryRef)
            {
                return state.memory[location.As<VmMemoryRef>().value];
            }

            return location;
        }

        public static void AssignLocation(this IType destination, VmState state, IType value)
        {
            if (destination is VmRegisterRef)
            {
                state.SetRegister(destination.As<VmRegisterRef>().value, value);
            }
            else if (destination is VmMemoryRef)
            {
                state.memory[destination.As<VmMemoryRef>().value] = value;
            }
            else
            {
                throw new Exception("Destination wasn't usable.");
            }
        }
    }
}
