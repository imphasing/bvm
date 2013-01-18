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
    }
}
