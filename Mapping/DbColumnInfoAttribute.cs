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
        public string DbTypeName { get; set; }

        public RelationModelColumnSetting ColumnSetting { get; set; }

        public DbColumnInfoAttribute(string dbTypeName = null, bool IsPrimaryKey = false, bool AllowNull = false)
        {
            //要引用relation默认规则
                     
        }

    }
}
