﻿using System;
using System.Collections.Generic;

namespace MyORMFrame.Mapping
{
    public interface IMappingDataSet
    {
        void InputType(Type type);

        void InputTypes(List<Type> types);

        void RemoveMappingData(Type type);

        IMappingData this[Type type] { get; }
    }
}