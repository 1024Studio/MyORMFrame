using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class ModelMappingInfo
    {
        public DbTableInfoAttribute DbTableInfo { get; set; }

        public Dictionary<string, DbColumnInfoAttribute> DbColumnInfos { get; set; }
    }
}
