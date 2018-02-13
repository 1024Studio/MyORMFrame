using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    //废弃
    public class MappingDataFactory : IMappingDataFactory
    {
        public IMappingData GetMappingData(Type type)
        {       
            return null;

            throw new NotImplementedException();            
        }
    }
}
