using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Attributes
{
    public class TypeAttribute : DbAttribute
    {
        public string DbTypeName { get; set; }

        public string Size { get; set; }

        public TypeAttribute(string dbType, string size = null)
        {
            this.DbTypeName = dbType;

            this.Size = size;
        }
    }
}
