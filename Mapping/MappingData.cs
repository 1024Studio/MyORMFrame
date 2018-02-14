using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyORMFrame.Mapping
{
    public class MappingData : IMappingData
    {
        DbTableInfoAttribute dbTableInfo;

        List<DbColumnInfoAttribute> dbColumnInfos;

        Func<Type, string> typeMappingMethod;

        public MappingData(Type type, Func<Type, string> typeMappingMethod)
        {
            dbColumnInfos = new List<DbColumnInfoAttribute>();
            this.typeMappingMethod = typeMappingMethod;

            var attrs = System.Attribute.GetCustomAttributes(type);
            foreach (var attr in attrs)
            {
                if (attr is DbTableInfoAttribute)
                {
                    dbTableInfo = (DbTableInfoAttribute)attr;

                    break;
                }
            }
            //如果没有添加特性，则构建特性
            if (dbTableInfo == null)
            {
                dbTableInfo = new DbTableInfoAttribute(type.Name);
            }

            //遍历属性特性
            var members = type.GetProperties();
            foreach (var member in members)
            {
                DbColumnInfoAttribute member_dbAttr = null;
                var member_attrs = System.Attribute.GetCustomAttributes(member);
                foreach (var member_attr in member_attrs)
                {
                    if (member_attr is DbColumnInfoAttribute)
                    {
                        member_dbAttr = (DbColumnInfoAttribute)member_attr;

                        break;
                    }
                }

                //如果该成员属性没有设定特性，则构建
                if (member_dbAttr == null)
                {
                    string member_typeName = typeMappingMethod(member.PropertyType);
                    if (member_typeName == null)
                        throw new Exception("类型转换失败，找不到此类型所适配的映射类型");

                    member_dbAttr = new DbColumnInfoAttribute(member.Name, member_typeName);
                }

                //添加
                dbColumnInfos.Add(member_dbAttr);
            }
        }

        public object ParseModel(DataSet dataSet)
        {
            //另外写一个对象构造器
            dataSet
            return null;
        }
    }
}
