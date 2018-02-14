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

        public DbTableInfoAttribute(string dbTableName)
        {
            if (dbTableName == null)
                throw new Exception("DbTableInfoAttribute参数不能为null值");

            this.DbTableName = dbTableName;
        }
    }
}
