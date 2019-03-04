using System.Data;

namespace Bobson.Core.DAO
{
    public interface IDbConnectionManager
    {
        IDbConnection CreateDbConnection();

        IDbDataAdapter CreateDbDataAdapter();

        IDbCommand CreateCommand();

        IDbConnection CreateDbConnection(string providerName, string connectionString);

        IDbDataAdapter CreateDbDataAdapter(string providerName);

        IDbCommand CreateDbCommand(string providerName);
    }
}
