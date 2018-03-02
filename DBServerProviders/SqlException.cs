using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.DBServerProvider
{
    public class SqlException : Exception
    {
        public int Number { get; }

        public SqlException(string message, Exception innerException, int number):base(message, innerException)
        {
            this.Number = number;
        }

    }
}
