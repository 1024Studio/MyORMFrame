using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.Mapping;

namespace MyORMFrame.DBContext
{
    public class DbQuery<T> : IQueryable<T> ,IDbQuery
    {
        private List<T> ModelCatches { get; set; }

        private List<Log> Logs { get; set; }

        public IMappingDataSet MappingDataSet { get; set; }

        public DBServer.DbServerBase DbServer { get; set; }

        public DbQuery()
        {
            _expression = Expression.Constant(this);

            ModelCatches = new List<T>();

            Logs = new List<Log>();
        }

        public DbQuery(Expression expression, DbQueryProvider provider) : base()
        {
            _expression = expression;
            this.provider = provider;     
        }
        /// <summary>
        /// 汇总查询结果到缓存
        /// </summary>
        public void JoinCatches(IEnumerable<T> models)
        {
            if (models != null && models.Count() > 0)
            {
                var modelUtil = MappingDataSet.GetMapper(typeof(T)).GetModelUtil();

                if (modelUtil.PrimaryKeyPropertyName != null)
                {
                    //如果是有主键标识的话，按主键合并
                    foreach (var m in models)
                    {
                        var res = ModelCatches.Where(a => modelUtil.GetPrimaryKeyValue(a) == modelUtil.GetPrimaryKeyValue(m)).ToList();
                        if (res.Count > 0)
                        {
                            //如果已经存在这个对象则合并
                            //遍历属性
                            foreach (var p in ElementType.GetProperties())
                            {
                                if (modelUtil.GetPropertyValue(res[0], p.Name) == null)
                                {
                                    modelUtil.SetPropertyValue(res[0], p.Name, modelUtil.GetPropertyValue(m, p.Name));
                                }
                            }
                        }
                        else
                        {
                            //否则添加
                            ModelCatches.Add(m);
                        }
                    }
                }
            }
            
        }

        public void Add(T model)
        {
            //记录日志
        }
        public void Update(Func<T, bool> method, T model)
        {
            //记录日志
        }
        public void Delete(Func<T, bool> method)
        {
            //记录日志
            //Log<T> log = new Log<T>(Log<T>.OperationType.Delete, method, null);
        }
        public T Find(Func<T, bool> method)
        {
            //先从缓存中查找, 没有查到去数据库查找
            var res = ModelCatches.Where(method).First();
            if (res == null)
            {
                //查找数据库，并执行查询
                this.Where(method).ToList();

                return ModelCatches.Where(method).First();
            }
            else
            {
                return res;
            }
        }

        public DbQuery<T> Load<TProperty>(Expression<Func<T,TProperty>> expression = null)
        {
            var ex = Expression;
            if (expression != null)
            {
                ex = Expression.Block(Expression, expression);
            }
            return new DbQuery<T>(ex, (DbQueryProvider)Provider);
        }

        public List<Log> GetOprationLogs()
        {
            return Logs;
        }

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        private Expression _expression;
        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }

        private IQueryProvider provider;
        public IQueryProvider Provider
        {
            get
            {
                if (provider == null)
                    provider = new DbQueryProvider(DbServer);

                return provider;
                
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var res = ((DbQueryProvider)Provider).ExecuteList<T>(Expression);

            return res.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class Log
    {
        public OperationType Type { get; }

        public Expression Where { get; }

        public Type ModelType { get; }

        public object Model { get; }

        public Log(Type modelType, OperationType type, Expression where, object model)
        {
            this.Type = type;
            this.ModelType = modelType;
            this.Where = where;
            this.Model = model;
        }

        public enum OperationType
        {
            Add = 1,
            Update = 2,
            Delete = 3
        }
    }
}
