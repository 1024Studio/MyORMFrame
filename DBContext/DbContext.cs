using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMFrame.DBServer;
using MyORMFrame.Mapping;

namespace MyORMFrame.DBContext
{
    public class DbContext
    {
        private DbQueryProvider provider;

        private IMappingDataSet mappingDataSet;

        private List<IDbQuery> dbQueriers;

        public DbContext(string name)
        {
            var dbServer = new DbServerBase(name);

            provider = new DbQueryProvider(dbServer);

            mappingDataSet = new MappingDataSet(Mapper.MapperCreator);

            this.dbQueriers = new List<IDbQuery>();

            InitDb();//初始化数据库上下文
        }
        private void InitDb()
        {
            //连接状态记录表，检测实体关系模型是否与数据库匹配
            //若表不存在则初始化数据表

        }
        public void RegisteQuerier<TModel>(DbQuery<TModel> querier)
        {
            querier.Provider = provider;

            querier.MappingDataSet = this.MappingDataSet;

            this.dbQueriers.Add((IDbQuery)querier);

            mappingDataSet.InputType(typeof(TModel));
        }

        public IMappingDataSet MappingDataSet
        {
            get { return mappingDataSet; }
        }

        public void SaveChange()
        {
            foreach (var d in dbQueriers)
            {

            }
        }
    }
}
