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
        private static ModelParser<T> parser;
        public static ModelParser<T> Parser
        {
            get
            {
                if (parser == null)
                {
                    parser = new ModelParser<T>();
                }
                return parser;
            }
        }
        private ModelParser()
        {

        }

        private List<RelationModel> relations;

        public T GetModel(DataSet dataSet)
        {
            //延迟读取技术
            return null;
        }
    }

}
