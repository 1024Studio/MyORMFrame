using System.Collections.Generic;
using System.Data;

namespace MyORMFrame.Mapping
{
    public interface IMappingData
    {
        RelationModel GetRelation(string relationName);
    }
}