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
        private IMappingDataSet mappingDataSet;

        private List<IDbQuery> dbQueriers;

        private DbServerBase dbServer;

        public DbContext(string name)
        {
            mappingDataSet = new MappingDataSet(Mapper.MapperCreator);

            dbServer = new DbServerBase(name, mappingDataSet);
           
            this.dbQueriers = new List<IDbQuery>();
        }
        public void InitDb()
        {
            //连接状态记录表，检测实体关系模型是否与数据库匹配
            //若表不存在则初始化数据表
            if (dbServer.IsTableExist("_relationState"))
            {
                //存在，验证是否匹配
            }
            else
            {
                //不存在,实例化关系模型(建表)
                foreach (var r in mappingDataSet.GetAllRelations())
                {
                    dbServer.CreateTable(r);
                }

                //最后建立relationState表
                dbServer.CreateTable(mappingDataSet.GetRelationState());
            }

        }
        public void RegisteQuerier<TModel>(DbQuery<TModel> querier)
        {
            querier.DbServer = this.dbServer;

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
