using Bobson.Core.Base;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Bobson.Core.DAO
{
    public class DbConnectionManager : IDbConnectionManager
    {
        public IDbConnection CreateDbConnection()
        {
            ConnectionStringSettings connString = Config.DefaultConnectionSettings;
            return CreateDbConnection(connString.ProviderName, connString.ConnectionString);
        }

        public IDbDataAdapter CreateDbDataAdapter()
        {
            return CreateDbDataAdapter(Config.DefaultConnectionSettings.ProviderName);
        }

        public IDbCommand CreateCommand()
        {
            return CreateDbCommand(Config.DefaultConnectionSettings.ProviderName);
        }

        public IDbConnection CreateDbConnection(string providerName, string connectionString)
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            IDbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public IDbDataAdapter CreateDbDataAdapter(string providerName)
        {
            return DbProviderFactories.GetFactory(providerName).CreateDataAdapter();
        }

        public IDbCommand CreateDbCommand(string providerName)
        {
            return DbProviderFactories.GetFactory(providerName).CreateCommand();
        }

    }
}
