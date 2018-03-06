using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MyORMFrame.Mapping;

namespace MyORMFrame.LambdaToSql
{
    public class LambdaTranslator
    {
        private static IMappingDataSet MappingDataSet;

        public static string where = string.Empty;

        /// <summary>
        /// 
        /// </summary>
       // private static List<string> parameters = new List<string>();

        private static List<Type> types = new List<Type>();

        private static List<string> Wheres = new List<string>();

        private static Dictionary<string, string> expressionCatches = new Dictionary<string, string>(); //存放已经处理过的表达式

        private static string[] JoinCatches = new string[2] { null, null};

        public void BindMappingDataSet(IMappingDataSet mappingDataSet)
        {
            MappingDataSet = mappingDataSet;
        }

        /// <summary>
        /// 分析Expression串
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="isInit">是否初始化生产模板</param>
        public static void ResolveExpression(Expression expression, bool isInit = false)
        {
            ExpressionType exType = expression.NodeType;

            if (isInit)
            {
                //parameters.Clear();

                types.Clear();

                Wheres.Clear();

                expressionCatches.Clear();

                JoinCatches[0] = JoinCatches[1] = null;
            }
            
            switch (exType)
            {
                case ExpressionType.Block:
                    foreach (var b in (expression as BlockExpression).Expressions)
                    {
                        ResolveExpression(b);
                    }
                    break;
                case ExpressionType.Call:
                    ResolveMethodCallExpression(expression as MethodCallExpression);
                    break;
                case ExpressionType.Lambda:
                    ResolveLambdaExpression(expression as LambdaExpression);
                    break;
                case ExpressionType.MemberAccess:
                    break;
                case ExpressionType.Parameter:
                    break;
                default:
                    break;
            }
        }

        private static string ResolveLambdaExpression(LambdaExpression expression)
        {
            string res = null;

            if (expression.Body.NodeType == ExpressionType.Parameter)
            {
                res = ResolveParameterExpression(expression.Body as ParameterExpression);
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                res = ResolveMemberExpression(expression.Body as MemberExpression);
            }
            else if (expression.Body.NodeType == ExpressionType.And)
            {

            }
            else if (expression.Body.NodeType == ExpressionType.AndAlso)
            {

            }
                      
            return res;
        }

        public static string ResolveMemberExpression(MemberExpression expression)
        {
            //展开成员表达式
            if (!expressionCatches.Keys.Contains(expression.ToString()))
            {
                var memberType = expression.Type;

                var typeMapping_rightType = DbTypeMapping.TypeMapping(memberType);

                if (typeMapping_rightType.Equals(DbTypeMapping.List_UserType))
                {
                    //如果成员表达式的右边是集合类型
                    if (!types.Contains(memberType))
                    {
                        types.Add(memberType);
                    }

                    expressionCatches.Add(expression.ToString(), null);
                    return null;
                }
                else if (typeMapping_rightType.Equals(DbTypeMapping.UserType))
                {
                    //如果成员表达式的右边是用户类型

                    CreateJoin(memberType.Name); //构造多关系连接

                    if (!types.Contains(memberType))
                    {
                        types.Add(memberType);
                    }

                    if (expression.Expression.NodeType == ExpressionType.Parameter)
                    {
                        ResolveParameterExpression(expression.Expression as ParameterExpression);
                    }
                    else if (expression.Expression.NodeType == ExpressionType.MemberAccess)
                    {
                        ResolveMemberExpression(expression.Expression as MemberExpression);
                    }

                    expressionCatches.Add(expression.ToString(), null);
                    return null;
                }
                else
                {
                    //如果成员表达式的右边是值类型
                    var memberName = expression.Member.Name;

                    string RelationName = null;

                    if (expression.Expression.NodeType == ExpressionType.Parameter)
                    {
                        RelationName = ResolveParameterExpression(expression.Expression as ParameterExpression);
                    }
                    else if (expression.Expression.NodeType == ExpressionType.MemberAccess)
                    {
                        RelationName = (expression.Expression as MemberExpression).Type.Name;

                        ResolveMemberExpression(expression.Expression as MemberExpression);
                    }

                    expressionCatches.Add(expression.ToString(), RelationName + "." + memberName);
                    return RelationName + "." + memberName;
                }
            }
            else
            {
                return expressionCatches[expression.ToString()];
            }
                
        }

        private static void ResolveMethodCallExpression(MethodCallExpression expression)
        {
            var methodName = expression.Method.Name;
            if (methodName.Equals("Where"))
            {
                foreach (var a in expression.Arguments)
                {
                    if (a.NodeType == ExpressionType.Quote)
                    {
                        ResolveUnaryExpression(a as UnaryExpression);
                    }
                    else if(a.NodeType == ExpressionType.Call)
                    {
                        ResolveMethodCallExpression(a as MethodCallExpression);
                    }
                }
            }
            
        }

        private static void ResolveUnaryExpression(UnaryExpression expression)
        {
            var res = expression.NodeType;
        }
        private static string ResolveConstantExpression(ConstantExpression expression)
        {
            return "123";
        }

        private static string ResolveParameterExpression(ParameterExpression expression)
        {
            var parameterType = (expression as ParameterExpression).Type;

            var typeMapping_parameterType = DbTypeMapping.TypeMapping(parameterType);

            if(typeMapping_parameterType.Equals(DbTypeMapping.List_UserType))
            {
                if (!types.Contains(parameterType))
                {
                    types.Add(parameterType);
                }

                return null;
            }
            else if (typeMapping_parameterType.Equals(DbTypeMapping.UserType))
            {
                CreateJoin(parameterType.Name, true);

                if (!types.Contains(parameterType))
                {
                    types.Add(parameterType);
                }

                return (expression as ParameterExpression).Type.Name;
            }
            else
            {
                return null;
            }          
        }

        private static void CreateJoin(string expression, bool isLast = false)
        {
            if (JoinCatches[1] == null)
            {
                if (!isLast)
                    JoinCatches[1] = expression;
            }
            else
            {
                JoinCatches[0] = expression;

                var join = JoinCatches[0] + ".[primaryKey] = " + JoinCatches[1] + ".[primaryKey]";

                if (!Wheres.Contains(join))
                {
                    Wheres.Add(join);
                }

                JoinCatches[0] = JoinCatches[1] = null;
            }
            
        }
    }

    public class TranslatorResult
    {
        //public List<string> 
    }
}
