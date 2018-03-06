using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.LambdaToSql;
using System.Linq.Expressions;
namespace MyORMFrame.Test
{
    public class lambdaTranslatorTest
    {
        public static void Main(string[] args)
        {

            InputExpression(a=>a.Id == 123);
        }

        public static void InputExpression(Expression<Func<Student,bool>> expression)
        {
            LambdaTranslator.ResolveExpression(expression);
        }
    }
}
