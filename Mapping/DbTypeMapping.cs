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
        public readonly static DbType List_UserType = new DbType { TypeName = "List_UserType", DefaultSize = string.Empty };

        static Dictionary<Type, DbType> mappings { get; set; }

        public static DbType TypeMapping(Type type)
        {
            if (mappings == null)
            {
                //实例化类型映射表
                mappings = new Dictionary<Type, DbType>();

                mappings.Add(typeof(int), new DbType { TypeName="int", DefaultSize = "255"});
                mappings.Add(typeof(string), new DbType { TypeName = "varchar", DefaultSize = "255" });
            }
            try
            {
                var res = mappings[type];

                return res;
            }
            catch(Exception ex)
            {
                if (type.GetInterface("IEnumerable`1") != null)
                {
                    return List_UserType;
                }
                else
                {
                    return UserType;
                }
            }

            
            //格式: c# Type => "TypeName,DefaultSize"
            //例子: System.Int32 => "int,9"
            //
        }
    }
    public class DbType
    {
        public string TypeName { get; set; }

        public string DefaultSize { get; set; }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode() == this.GetHashCode();
        }
        public override int GetHashCode()
        {
            return TypeName.GetHashCode();
        }
    }
}
