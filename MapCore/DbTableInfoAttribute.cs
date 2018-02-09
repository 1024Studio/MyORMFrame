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
        public string DbTableName { get; set; }

        public DbTableInfoAttribute(string dbTableName)
        {
            this.DbTableName = dbTableName;
        }
    }
}
