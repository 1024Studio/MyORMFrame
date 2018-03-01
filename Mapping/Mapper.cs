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

        Dictionary<string, PropertyMappingInfo> columnMappings;   //  列映射信息

        Dictionary<string, ModelUtil> modelUtil;    //model读写对象类

        public Mapper(Type type)
        {
            //成员变量初始化
            relationModels = new Dictionary<string, RelationModel>();

            RelationModel main_relation = new RelationModel(type.Name); //建立主关系

            //遍历成员属性
            var type_members = type.GetProperties();
            foreach (var m in type_members)
            {
                //RelationModelColumnSetting setting = null;


                //  读取列的用户定义属性
                var attrs = System.Attribute.GetCustomAttributes(m);  
                foreach(var attr in attrs)
                {

                }

                
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
        public static IMapper MapperCreator(Type type)
        {
            IMapper mapper = new Mapper(type);

            return mapper;
        }
    }
}
