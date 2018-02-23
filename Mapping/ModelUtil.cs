using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    public class ModelUtil
    {
        public string PrimaryKeyColumnName { get; set; }

        public Type ModelType { get; set; }

        public List<RelationModel> Relations { get; set; }
        
        public ModelUtil(Type type)
        {
            this.ModelType = type;
            //初始化
            //测试代码
            PrimaryKeyColumnName = "";
        }
        public object GetPrimaryKeyValue(object obj)
        {
            return GetPropertyValue(obj, PrimaryKeyColumnName);
        }

        public object GetPropertyValue(object obj, string propertyName)
        {
            if (obj.GetType().Equals(ModelType)) //检查类型
            {
                return ModelType.GetProperty(propertyName).GetValue(obj);
            }
            else
            {
                return null;
            }

            
        }
        public void SetPropertyValue<TValue>(object obj, string propertyName, TValue value)
        {
            if (obj.GetType().Equals(ModelType)) //检查类型
            {
                Type valueType = typeof(TValue);
                switch (valueType.Name)
                {
                    case "System.Int32":
                        ModelType.GetProperty(propertyName).SetValue(obj, int.Parse(value.ToString()));
                        break;
                    case "System.String":
                        break;
                    case "System.Bool":
                        break;
                    default:
                        ModelType.GetProperty(propertyName).SetValue(obj, value);
                        break;
                }
            }
        }
        public PropertyMappingInfo GetPropertyMappingInfo(string propertyName)
        {
            PropertyMappingInfo info = new PropertyMappingInfo();


            var property = ModelType.GetProperty(propertyName);

            Type propertyType = property.PropertyType;


            string propertyTypeName = TypeMapping(propertyType.Name);

            if (propertyTypeName == null)
            {
                //若映射类型名为null的话,则说明该列属性存在引用关系
                if (propertyType.GetInterface("IEnumerable`1") != null)
                {
                    //如果是集合,则验证是多对一，还是多对多关系。
                    var argTypes = propertyType.GetGenericArguments();//获取集合中的元素的数据类型
                    if (argTypes.Length == 1)
                    {
                        //若是合法集合，验证是多对一，还是多对多关系。
                        var referenceModelType = argTypes[0];
                        //验证目标model是否包含关于自身的泛型集合，已确定是多对一还是多对多
                        bool isContainListOfSelf = false;
                        foreach (var p in referenceModelType.GetProperties())
                        {
                            if (p.PropertyType.GetInterface("IEnumerable`1") != null)
                            {
                                var other_argTypes = p.PropertyType.GetGenericArguments();
                                if (other_argTypes.Length == 1 && other_argTypes[0].Equals(ModelType))
                                {
                                    isContainListOfSelf = true;
                                    break;
                                }
                            }
                        }

                        if (!isContainListOfSelf)
                        {
                            //多对一关系
                            info.ReferenceModelType = referenceModelType;
                            info.Property_TypeRole = PropertyMappingInfo.PropertyTypeRole.ModelList_To_Obj;
                        }
                        else
                        {
                            //多对多关系
                            info.ReferenceModelType = referenceModelType;
                            info.Property_TypeRole = PropertyMappingInfo.PropertyTypeRole.ModelList_To_List;
                        }
                        
                    }
                    else
                    {
                        //不接受多类型泛型集合，抛出异常
                    }
                }
                else
                {
                    //否则是单引用关系
                    //若是单引用关系,则目标关系必须包含主键(外键)
                    string other_primaryKeyName = new ModelUtil(propertyType).PrimaryKeyColumnName;
                    if (other_primaryKeyName != null)
                    {
                        info.Property_TypeRole = PropertyMappingInfo.PropertyTypeRole.Model;
                        info.ReferenceModelType = propertyType;
                    }
                    else
                    {
                        //否则抛出异常

                    }
                    
                }
            }
            else
            {
                info.Property_TypeRole = PropertyMappingInfo.PropertyTypeRole.Value;
                info.DbTypeName = propertyTypeName;
            }
            return info;
        }

        public static string TypeMapping(string typeName)
        {
            //基本类型映射
            return null;
        }
    }
}
