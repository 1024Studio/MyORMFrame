using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.DBContext;
using System.Linq.Expressions;
namespace MyORMFrame.Test
{
    public class DbQueryTest
    {
        public static void Main(string[] args)
        {
                       
        }

        public static void Method(Expression<Func<Student, bool>> method)
        {
            Type type = method.GetType();

        }


    }
}
