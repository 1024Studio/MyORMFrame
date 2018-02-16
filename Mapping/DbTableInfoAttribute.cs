using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class DbTableInfoAttribute : Attribute
    {
        public string DbTableName { get; set; }

        public DbTableInfoAttribute(string dbTableName = null)
        {
            this.DbTableName = dbTableName;
        }
    }
}
