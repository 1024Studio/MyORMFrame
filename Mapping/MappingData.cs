using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public class MappingData : IMappingData
    {
        DbTableInfoAttribute dbTableInfo;

        List<DbColumnInfoAttribute> dbColumnInfos;

        public MappingData(Type type)
        {
            dbColumnInfos = new List<DbColumnInfoAttribute>();

            var attrs = System.Attribute.GetCustomAttributes(type);
            var typeMembers = type.
            foreach (var attr in attrs)
            {
                if (attr is DbTableInfoAttribute)
                {
                    dbTableInfo = (DbTableInfoAttribute)attr;
                }
                else if (attr is DbColumnInfoAttribute)
                {
                    dbColumnInfos.Add((DbColumnInfoAttribute)attr);
                }
            }
        }


    }
}
