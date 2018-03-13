using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyORMFrame.ModelParser
{
    public class ModelParser<TModel>
    {
        public static List<TModel> Parse(DataSet dataSet)
        {
            Type modelType = typeof(TModel);

            DataTable main_dt = dataSet.Tables[""];
            return null;
        }

        private static object LoadModelProperty(DataSet dataSet)
        {
            return null;
        }
        /// <summary>
        /// 读取一对多关系的ListModel
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private static List<object> LoadModelListProperty_0(DataSet dataSet)
        {
            return null;
        }
        /// <summary>
        /// 读取多对多关系的ListModel
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        private static List<object> LoadModelListProperty_1(DataSet dataSet)
        {
            return null;
        } 
    }
}
