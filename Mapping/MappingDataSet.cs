using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    public class MappingDataSet : IMappingDataSet
    {
        //可能废弃
        Dictionary<Type, IMappingData> modelsMappingDataSet;

        Func<Type,IMappingData> mappingDataCreator;

        public MappingDataSet(Func<Type,IMappingData> mappingDataCreator)
        {
            modelsMappingDataSet = new Dictionary<Type, IMappingData>();

            this.mappingDataCreator = mappingDataCreator;
        }

        public void InputType(Type type)
        {
            if (modelsMappingDataSet[type] == null)
            {
                //如果映射集没有该类型的映射信息，则添加该类型
                var mappingData = mappingDataCreator(type);

                if (mappingData == null)
                    throw new Exception("生成mappingData失败");

                modelsMappingDataSet.Add(type, mappingData);
            }          
        }
        public void InputTypes(List<Type> types)
        {
            foreach (var type in types)
            {
                InputType(type);
            }
        }
        public void RemoveMappingData(Type type)
        {
            modelsMappingDataSet.Remove(type);
        }
        public IMappingData this[Type type]
        {
            get
            {
                return modelsMappingDataSet[type];
            }
        }
    }
}
