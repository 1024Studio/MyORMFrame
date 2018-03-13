using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Collections;

namespace MyORMFrame.Mapping
{
    public class Mapper : IMapper
    {
        Dictionary<string, RelationModel> relationModels;

        Dictionary<string, PropertyMappingInfo> columnMappings;     //  列映射信息

        ModelUtil modelUtil;                                        //model读写对象类

        public Mapper(Type type)
        {
            //成员变量初始化
            modelUtil = new ModelUtil(type);

            relationModels = new Dictionary<string, RelationModel>();

            List<RelationModel> relations = modelUtil.GetRelations();

            foreach (var r in relations)
            {
                relationModels.Add(r.TbName, r);
            }

            columnMappings = new Dictionary<string, PropertyMappingInfo>();

            foreach (var c in type.GetProperties())
            {
                columnMappings.Add(c.Name, modelUtil.GetPropertyMappingInfo(c.Name));
            }
                
            
        }
        public RelationModel GetRelation(string modelName)
        {
            return relationModels[modelName];
        }
        public List<RelationModel> GetRelations()
        {
            return relationModels.Values.ToList();
        }

        public PropertyMappingInfo GetColumnMappingInfo(string columnName)
        {
            return columnMappings[columnName];
        }

        public List<PropertyMappingInfo> GetColumnMappingInfos()
        {
            return columnMappings.Values.ToList();
        }
        public ModelUtil GetModelUtil()
        {
            return modelUtil;
        }
        public static IMapper MapperCreator(Type type)
        {
            IMapper mapper = new Mapper(type);

            return mapper;
        }
        
    }
}
