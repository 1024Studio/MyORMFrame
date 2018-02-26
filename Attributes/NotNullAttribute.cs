using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    public class NotNullAttribute : ConstraintAttribute
    {
        public override string GetConstraintStr()
        {
            return "NOT NULL";
        }
    }
}
