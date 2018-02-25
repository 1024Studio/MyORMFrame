using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    public abstract class DbAttribute : Attribute
    {
        public abstract bool IsLawful();
    }
}
