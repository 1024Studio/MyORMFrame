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
            //db.Students.Load(a => a.Class.id).Load(a=>a.Id).ToList();
            db.Students.Where(a=>a.Class != null).ToList();
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
