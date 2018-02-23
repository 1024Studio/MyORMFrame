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
                RelationModelColumnSetting setting = null;


                //  读取列的用户定义属性
                var attrs = System.Attribute.GetCustomAttributes(m);  
                foreach(var attr in attrs)
                {
                    if (attr is DbColumnInfoAttribute)
                    {
                        //如果用户有定义自定义属性的话
                    }
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

    public class PropertyMappingInfo
    {
        //逻辑列与关系列的映射关系
        public string DbTypeName { get; set; }  //对应的数据库数据类型名

        public PropertyTypeRole Property_TypeRole { get; set; } //该属性的数据类型类别，是一般类型，model类，还是model集合

        public Type ReferenceModelType { get; set; }    //该属性引用的其他model数据类型

        public enum PropertyTypeRole
        {
            Value = 0,
            Model = 1,
            ModelList_To_Obj = 2,
            ModelList_To_List = 3
        }
    }


}
