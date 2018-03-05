using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.Test
{
    public class DbContextTest
    {
        public static void Main(string[] args)
        {
            var db = new MyDbConext();
            db.Students.Select(a => a.Books).ToList();
        }

    }
    public class MyDbConext : DBContext.DbContext
    {
        public DBContext.DbQuery<Student> Students { get; set; }

        public MyDbConext() : base("123")
        {
            this.Students = new DBContext.DbQuery<Student>();

            this.RegisteQuerier<Student>(Students);
        }
    }
}
