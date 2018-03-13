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
            var select_sql = Select.From(new List<string> { "table_0", "table_1" })
                .AddColumns("column0")
                .AddColumns("column1")
                .SetWhere("aaa = 111")
                .ToSql();
            Console.Write(select_sql.ToString());
            Console.Read();
            return;
        }
    }
}
