using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.SQL
{
    public class SqlScript
    {
        private string sql { get; set; }
        public SqlScript(string sqlScript)
        {
            sql = sqlScript;
        }

        public override string ToString()
        {
            return sql;
        }

    }
}
