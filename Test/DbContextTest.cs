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
            db.Students.Where(a=>a.Class.Name == "f140114").ToList();
        }

    }
    public class MyDbConext : DBContext.DbContext
    {
        public DBContext.DbQuery<Student> Students { get; set; }

        public DBContext.DbQuery<Course> Course { get; set; }

        public MyDbConext() : base("123")
        {
            this.Students = new DBContext.DbQuery<Student>();

            this.Course = new DBContext.DbQuery<Test.Course>();

            this.RegisteQuerier<Student>(Students);

            this.RegisteQuerier<Course>(Course);

            base.InitDb();
        }
    }
}
