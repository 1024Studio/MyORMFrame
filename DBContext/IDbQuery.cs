using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.DBContext
{
    interface IDbQuery
    {
        List<Log> GetOprationLogs();
    }
}
