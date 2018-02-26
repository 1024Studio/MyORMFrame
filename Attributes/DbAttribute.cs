using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    [AttributeUsage( AttributeTargets.Property,AllowMultiple = true)]
    public abstract class DbAttribute : Attribute
    {

    }
}
