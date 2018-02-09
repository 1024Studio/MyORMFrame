using System;
using System.Collections.Generic;

namespace Mapping
{
    public interface IMappingDataSet
    {
        //void InputMappingDataSet(Dictionary<Type, MappingData> modelsMappingDataSet);

        void InputType(Type type);

        void InputTypes(ICollection<Type> types);

        void RemoveMappingData(Type type);

        IMappingData this[Type type] { get; }
    }
}