using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyORMFrame.Mapping;
using System.Data;

namespace MyORMFrame.ModelParser
{
    //Model析出查询器
    public class ModelQuery<TModel> : IModelQuery<TModel>
    {
        private IMapper mapper;

        private DataSet dataSet;

        private List<TModel> models;    //models池

        public ModelQuery(IMapper mapper, DataSet dataSet)
        {
            this.mapper = mapper;
            this.dataSet = dataSet;
        }
        public IModelQuery<TModel> Load(Func<TModel, bool> selectMethod = null)
        {
            if (models == null)
            {
                models = new List<TModel>();

                Type model_type = typeof(TModel);

                var properties = model_type.GetProperties();    //获取model的所有属性
                var table = dataSet.Tables[mapper.GetRelation(model_type.Name).TbName]; //要用到的主查询表

                var rows = table.Rows;  //  筛选rows,未完成

                foreach (var r in rows)
                {
                    //遍历rows,构造Model
                    //反射构建对象
                    TModel model = (TModel)model_type.Assembly.CreateInstance(model_type.Name);
                    foreach (var p in properties)
                    {
                        //遍历字段属性
                        var columnMapping = mapper.GetColumnMappingInfo(p.Name);
                        if (columnMapping.PropertyTypeRole == PropertyMappingInfo.ReferenceType.NoRef)
                        {
                            //赋值于值字段
                            p.SetValue(model, "");
                        }
                    }
                }
            }                            
            return this;
        }

        public IModelQuery<TModel> LoadProperty(string propertyName) //待解决a.property.property问题 
        {
            if (models == null)
            {
                //如果models池是空的话，则预读
                Load();
            }
            else
            {
                //否则读取指定列
                var columnMappinfo = mapper.GetColumnMappingInfo(propertyName); //欲读列的关系引用类型
                             
                foreach (var m in models)
                {
                    if (res == null)
                    {
                        //如果欲读属性为空的话，则读取
                        if (refType == PropertyMappingInfo.ReferenceType.One_to_one)
                        {
                            res.
                        }
                        else if (refType == PropertyMappingInfo.ReferenceType.one_to_many)
                        {

                        }
                        else if (refType == PropertyMappingInfo.ReferenceType.Many_to_many)
                        {

                        }
                    }
                }
            }

            return this;
        }

        public IList<TModel> ToList()
        {
            return models;
        }
    } 

}
