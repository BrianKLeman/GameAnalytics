using MySql.Data.MySqlClient;
using LinqToDB.DataProvider.MySql;
using LinqToDB.Data;

namespace DataAccessLayer.GameAnalyticsRepository
{
    public abstract class GamesDataAccessBase
    {
        protected DataConnection NewDataConnection()
        {
            var cBuilder = new MySqlConnectionStringBuilder();
            cBuilder.Server = DatalayerConfig.GetHost();
            cBuilder.Port = DatalayerConfig.GetPort();
            cBuilder.UserID = DatalayerConfig.GetGameAnalyticsUserName();
            cBuilder.Password = DatalayerConfig.GetPassword();
            cBuilder.Database = DatalayerConfig.GetGameAnalyticsDatabaseName();

            return MySqlTools.CreateDataConnection(cBuilder.ConnectionString);
        }
    }
}
