using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    //废弃
    public class MappingDataFactory
    {
        static Dictionary<Type, string> typeMappingStrs;

        public static IMappingData GetMappingData(Type type)
        {
            IMappingData mappingData = new MappingData(type, typeMappingMethod);

            return mappingData;      
        }

        public static string typeMappingMethod(Type type)
        {
            if (typeMappingStrs == null)
            {
                //初始化映射列表
                typeMappingStrs = new Dictionary<Type, string>();

                typeMappingStrs.Add(typeof(int), "int");
            }

            //表达异常
            return typeMappingStrs[type];
        }
    }
}
