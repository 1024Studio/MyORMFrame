using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
   [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DbColumnInfoAttribute : Attribute
    {
        public string dbColumnName { get; set; }
        public string dbTypeName { get; set; }

        public DbColumnSetting dbColumnSetting { get; set; }

        public DbColumnInfoAttribute(string dbColumnName, DbColumnSetting dbColumnSetting = null)
        {
            this.dbColumnName = dbColumnName;
            this.dbColumnSetting = dbColumnSetting;

            if (this.dbColumnSetting == null)
            {
                this.dbColumnSetting = DbColumnSetting.DefaultColumnSetting;
            }
            
        }
    }
    /*
     * 自定义数据类型映射关系
     */

}
