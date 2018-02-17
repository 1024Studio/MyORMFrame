using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyORMFrame.Mapping;
using System.Data;

namespace MyORMFrame.ModelParser
{
    public class ModelParser<T>
    {
        public ModelParser()
        {

        }

        public List<T> GetModels(DataSet dataSet, Func<string, object> loadMethod)
        {
            //延迟读取技术,有问题
            loadMethod = a => a.Length;
            return null;
        }
    }

}
