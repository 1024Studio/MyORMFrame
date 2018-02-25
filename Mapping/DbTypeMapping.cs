using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    /// <summary>
    /// 数据类型映射器
    /// </summary>
    public class DbTypeMapping
    {
        public readonly static DbType UserType = new DbType { TypeName = "UserType", DefaultSize = string.Empty };
        static Dictionary<Type, DbType> mappings { get; set; }

        public static DbType TypeMapping(Type type)
        {
            if (mappings == null)
            {
                //实例化类型映射表
                mappings = new Dictionary<Type, DbType>();

            }

            var res = mappings[type];

            if (res == null)
            {
                res = UserType;
            }

            return res;


            //格式: c# Type => "TypeName,DefaultSize"
            //例子: System.Int32 => "int,9"
            //
        }
    }
    public class DbType
    {
        public string TypeName { get; set; }

        public string DefaultSize { get; set; }
    }
}
