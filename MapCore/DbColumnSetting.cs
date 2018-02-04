using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class DbColumnSetting
    {
        public bool IsPrimaryKey { get; set; }
        public bool AllowNull { get; set; }

        public int Size { get; set; }
        
       
        public static DbColumnSetting DefaultColumnSetting{
            get{
                DbColumnSetting defaultColumnSetting = new DbColumnSetting();

                defaultColumnSetting.IsPrimaryKey = false;
                defaultColumnSetting.AllowNull = false;

                return defaultColumnSetting;
            }

        }
    }
}
