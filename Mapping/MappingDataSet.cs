using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class MappingDataSet : IMappingDataSet
    {
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
                //如果映射集中没有该类型的映射信息，则添加该类型
                var mappingData = mappingDataCreator(type);

                modelsMappingDataSet.Add(type, mappingData);
            }          
        }
        public void InputTypes(ICollection<Type> types)
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
