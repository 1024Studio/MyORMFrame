using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.SQL
{
    public interface ISqlHelper
    {
        SqlScript ToSql();
    }
}
