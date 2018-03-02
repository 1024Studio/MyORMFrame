using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.SQL;

namespace MyORMFrame.Test
{
    public class SqlTest
    {
        public static void Main(string[] args)
        {
            var sql = CreateTable.CreateTb("asdad")
                .AddColumn("asd","12","2","")
                .AddColumn("dadasd","123","3","")
                .ToSql();

            Console.Write(sql.ToString());
            Console.Read();
            return;
        }
    }
}
