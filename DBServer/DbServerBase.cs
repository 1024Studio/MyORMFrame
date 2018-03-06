using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using MyORMFrame.Mapping;
using MyORMFrame.DBServerProvider;
using MyORMFrame.SQL;
using MyORMFrame.LambdaToSql;
namespace MyORMFrame.DBServer
{
    public class DbServerBase
    {
        private IDbServerProvider DbServerProvider { get; set; }

        public DbServerBase(string name)
        {
            this.DbServerProvider = DbAccess.GetDbServerProvider(name);
        }       
        public void CreateDb(string dataBaseName)
        {
            DbServerProvider.ExcuteNonQuery(CommandType.Text, CreateDB.CreateDb(dataBaseName).ToSql().ToString());         
        }
        public void CreateTable(RelationModel relation)
        {
            var a = SQL.CreateTable.CreateTb(relation.TbName);
            foreach (var c in relation.Columns)
            {
                a.AddColumn(c.ColumnName, c.TypeName, c.Size, c.ConstraintsStr);
            }
            SqlScript sql = a.ToSql();   

            DbServerProvider.ExcuteNonQuery(CommandType.Text, sql.ToString());
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(SqlScript sql)
        {
            return null;
        }

        public void Update(SqlScript sql)
        {

        }
        public List<TModel> SelectModels<TModel>(Expression expression)
        {
            LambdaTranslator.ResolveExpression(expression);
            return null;
        } 
        /// <summary>
        /// 带异常处理的数据库执行函数
        /// </summary>
        /// <param name="callback">需要执行的数据库操作</param>
        private void SafeExcute(Action callback)
        {
            try
            {
                callback();
            }
            catch (Exception ex)
            {
                if (ProcessSqlException(ex))
                {
                    callback();
                }
                else
                {
                    throw (ex);
                }
            }          
        }
        /// <summary>
        /// 处理数据库异常
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>处理成功返回true，否则返回false</returns>
        private bool ProcessSqlException(Exception ex)
        {
            SqlException sqlEx = DbServerProvider.ConvertToSqlException(ex);

            switch (sqlEx.Number)
            {
                case 4060:
                    CreateDb(DbServerProvider.DataBase);
                    return true;

                default:
                    return false;
            }
        }
    }
}
