using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class MappingDataFactory : IMappingDataFactory
    {
        public Dictionary<Type, IMappingData> GetMappingData(Type type)
        {
            return null;

            throw new NotImplementedException();            
        }
    }
}
