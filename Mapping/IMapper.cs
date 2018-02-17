using System;
using System.Collections.Generic;
using System.Data;

namespace MyORMFrame.Mapping
{
    public interface IMapper
    {
        List<RelationModel> GetRelations();
    }
}