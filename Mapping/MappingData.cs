using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyORMFrame.Mapping
{
    public class MappingData : IMappingData
    {
        Dictionary<string, RelationModel> relationModels;

        Func<Type, TypeMappingResult> typeMappingMethod;

        public MappingData(Type type, Func<Type, TypeMappingResult> typeMappingMethod)
        {
            var members = type.GetMembers();
            foreach (var member in members)
            {
                //首先读取custom特性
                //否则使用默认规则
            }
        }

        public RelationModel GetRelation(string relationName)
        {
            RelationModel relation = relationModels[relationName];

            if (relation == null)
                throw new Exception("没有找到该关系");

            return relation;
        }
    }

    public class TypeMappingResult
    {
        public string TypeName { get; set; }
        public static TypeMappingResult TypeMapping(Type type)
        {
            TypeMappingResult res = new TypeMappingResult();


            return res;
        }
    }
}
