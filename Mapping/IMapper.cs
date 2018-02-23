using System;
using System.Collections.Generic;
using System.Data;

namespace MyORMFrame.Mapping
{
    public interface IMapper
    {
        RelationModel GetRelation(string modelName);

        List<RelationModel> GetRelations();

        PropertyMappingInfo GetColumnMappingInfo(string columnName);
    }
}