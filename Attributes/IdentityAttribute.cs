using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    public class IdentityAttribute : ConstraintAttribute
    {
        public int seek { get; set; }

        public int increment { get; set; }
        public IdentityAttribute(int seek, int increment)
        {

        }
        public override string GetConstraintStr()
        {
            return string.Format("identity({0},{1})", increment, seek);
        }
    }
}
