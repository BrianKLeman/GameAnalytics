using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatalayerConfig
    {
        

        public static string GetHost()
        {
            return ConfigurationManager.AppSettings.Get("databaseHost");
        }

        public static uint GetPort()
        {
            return uint.Parse(ConfigurationManager.AppSettings.Get("databasePort"));
        }        

        public static string GetGameAnalyticsUserName()
        {
            return ConfigurationManager.AppSettings.Get("gameAnalyticsDatabaseUserName");
        }

        public static string GetGameAnalyticsDatabaseName()
        {
            return ConfigurationManager.AppSettings.Get("gameAnalyticsDatabaseName");
        }

        public static string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get("databasePassword");
        }

        public static string GetConnectString()
        {
            return "";
        }
    }
}
