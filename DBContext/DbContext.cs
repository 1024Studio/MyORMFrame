using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.DBServer;

namespace MyORMFrame.DBContext
{
    public class DbContext
    {
        private DbServer dbServer{ get; set; }

        public DbContext(string name)
        {
            dbServer = new DbServer(name);
        }
    }
}
