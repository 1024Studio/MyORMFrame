using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace MyORMFrame.DBAccess
{
    public sealed class DbAccess
    {
        private static string path = ConfigurationManager.AppSettings["DbServerProvider"];
        private static IDbServerProvider dbServerProvider;
        private DbAccess() { }

        public static IDbServerProvider DbServerProvider
        {
            get
            {
                if (dbServerProvider == null)
                {
                    //实例化dbserver 对象
                    dbServerProvider = (IDbServerProvider)Assembly.Load(path);
                }

                return dbServerProvider;
                
            }
        }
    }
}
