using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MyORMFrame.LambdaToSql
{
    public class LambdaTranslator
    {
        public static string ToSql(Expression expression)
        {
            if (expression is LambdaExpression)
            {

            }
            else if (expression is BinaryExpression)
            {

            }
            else if (expression is UnaryExpression)
            {

            }
            else if (expression is UnaryExpression)
            {

            }
            else if (expression is MethodCallExpression)
            {

            }
            else if (expression is MemberExpression)
            {

            }

            return "";
        }
    }
}
