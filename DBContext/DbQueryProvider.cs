using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyORMFrame.DBContext
{
    public class DbQueryProvider : IQueryProvider
    {
        private DBServer.DbServerBase dbServer { get; set; }

        public DbQueryProvider(DBServer.DbServerBase dbServer)
        {
            this.dbServer = dbServer;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            IQueryable query = new DbQuery<object>(expression, this);

            return query;
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            DbQuery<TElement> query = new DbQuery<TElement>(expression, this);

            return query;
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }
        public List<TResult> ExecuteList<TResult>(Expression expression)
        {
            return dbServer.SelectModels<TResult>(expression);
        }
    }
}
