using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Mapping
{
    //废弃
    public interface IMappingDataFactory
    {
        IMappingData GetMappingData(Type type);
    }
}
