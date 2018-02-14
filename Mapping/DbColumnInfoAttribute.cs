using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
   [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = true,Inherited = false)]
    public class DbColumnInfoAttribute : Attribute
    {
        public string dbColumnName { get; set; }
        public string dbTypeName { get; set; }

        //dbColumnSetting
        public bool IsPrimaryKey { get; set; }
        public bool AllowNull { get; set; }

        public DbColumnInfoAttribute(string dbColumnName, string dbTypeName, bool IsPrimaryKey = false, bool AllowNull = false)
        {
            if (dbColumnName == null || dbTypeName == null)
                throw new Exception("DbColumnInfoAttribute参数不能为null值");

            this.dbColumnName = dbColumnName;
            this.dbTypeName = dbTypeName;

            //dbColumnSetting
            this.IsPrimaryKey = IsPrimaryKey;
            this.AllowNull = AllowNull;
            
        }

    }
}
