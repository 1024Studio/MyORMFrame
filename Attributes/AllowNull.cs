using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    public class AllowNull : Attribute
    {
        public bool allowNull { get; set; }

        public AllowNull(bool allowNull)
        {
            this.allowNull = allowNull;
        }
    }
}
