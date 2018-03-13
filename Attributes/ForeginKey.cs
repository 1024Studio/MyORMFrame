using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    public class ForeginKeyAttribute : ConstraintAttribute
    {
        public override string GetConstraintStr()
        {
            return "ForeginKey";
        }
    }
}
