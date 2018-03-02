using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace MyORMFrame.DBServerProvider
{
    public sealed class DbAccess
    {
        private DbAccess() { }
        public static IDbServerProvider GetDbServerProvider(string name)
        {
            string providerName = ConfigurationManager.ConnectionStrings[name].ProviderName;

            IDbServerProvider provider = (IDbServerProvider)Type.GetType(providerName).Assembly.CreateInstance(providerName);

            provider.ConnectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;

            return provider;

        }
    }
    
}
