using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
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
            return typeMappingStrs[type];
        }
    }
}
