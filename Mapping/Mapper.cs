using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace MyORMFrame.Mapping
{
    public class Mapper : IMapper
    {
        Dictionary<string, RelationModel> relationModels;

        Dictionary<string, ColumnMapping> columnMappings;

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

        public List<RelationModel> GetRelations()
        {
            return relationModels.Values.ToList();
        }
        public static IMapper MapperCreator(Type type)
        {
            IMapper mapper = new Mapper(type);

            return mapper;
        }
    }

    public class ColumnMapping
    {
        public string ColumnName { get; set; }
        public string TypeName { get; set; }
        public ReferenceType RefType { get; set; }

        static Dictionary<Type, string> typeMapping;

        public ColumnMapping()
        {
            //初始化类型映射信息
        }
        public ColumnOfRelationModel GetColumnOfRelationModel()
        {
            return null;
        }
        public static ColumnMapping GetColumnMapping(PropertyInfo column)
        {
            ColumnMapping mapping = new ColumnMapping();

            mapping.TypeName = typeMapping[column.PropertyType];
            if (mapping.TypeName != null)
            {
                //如果找到相应的映射类型，则说明该列的逻辑模型的数据类型，与关系模型的数据类型是直接对应的
                //按值类型处理
                mapping.RefType = ReferenceType.NoRef;  //未参照其他关系
            }
            else
            {
                //否则按照引用类型处理
                if ( column.PropertyType != null )
                {
                    //如果该列数据类型是一维集合,则按多对N关系处理  
                                //多对N关系 (因为不确定该关系是主动引用还是被动引用，所以不确定是多对一还是多对多关系)
                }
                else 
                {
                    //否则是单引用关系
                }
            }

            return mapping;
        }


        public enum ReferenceType
        {
            NoRef = 0,          //没有引用关系
            One_to_one = 1,     //一对一关系
            one_to_many = 2,    //一对多关系
            Many_to_one = 3,    //多对一关系
            Many_to_many = 4    //多对多关系
        }
    }


}
