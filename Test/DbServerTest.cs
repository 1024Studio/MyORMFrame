using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MyORMFrame.DBServer;
using MyORMFrame.Mapping;

namespace MyORMFrame.Test
{
    public class DbServerTest
    {
        public static void Main(string[] args)
        {
            DbServerBase A = new DbServerBase("123");

            try
            {
                List<RelationModel> relations = new ModelUtil(typeof(Student)).GetRelations();
                A.CreateTable(relations[0]);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                //4060
                a = null;
            }
            return;
        }


    }
}
