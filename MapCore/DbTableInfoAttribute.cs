using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class DbTableInfoAttribute : Attribute
    {
        string dbTableName;

        public DbTableInfoAttribute(string dbTableName)
        {
            this.dbTableName = dbTableName;
        }
    }
}
