using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.ModelParser
{
    public interface IModelQuery<TModel>
    {
        IModelQuery<TModel> Load(Func<TModel,bool> selectMethod);                            //加载model
        IModelQuery<TModel> LoadProperty(string propertyName);                                //加载model属性
        IList<TModel> ToList();
    }
}
