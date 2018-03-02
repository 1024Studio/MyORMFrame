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
    public class ModelQuery<TModel>
    {
        private IMapper mapper;

        private DataSet dataSet;

        private List<TModel> models;    //models池

    }
}