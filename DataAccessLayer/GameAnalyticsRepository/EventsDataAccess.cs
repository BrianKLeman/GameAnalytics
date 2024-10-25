using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Extensions;
using LinqToDB.Tools;
namespace DataAccessLayer.GameAnalyticsRepository
{
    public class EventsDataAccess : GamesDataAccessBase, IEventsDataAccess
    {
        public int AddEvent(int gameId, string eventName, string userGuid, string eventData)
        {
            using (var connection = NewDataConnection())
            {
                var cmd = connection.Connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                var pars = cmd.Parameters;
                var p1 = cmd.CreateParameter();
                p1.Direction = System.Data.ParameterDirection.Input;
                p1.DbType = System.Data.DbType.String;
                p1.ParameterName = "P_GUID";
                p1.Value = userGuid;

                var p2 = cmd.CreateParameter();
                p2.Direction = System.Data.ParameterDirection.Input;
                p2.DbType = System.Data.DbType.Int16;
                p2.Value = gameId;
                p2.ParameterName = "P_EVENT_GAME_ID";

                var p3 = cmd.CreateParameter();
                p3.Direction = System.Data.ParameterDirection.Input;
                p3.DbType = System.Data.DbType.Int16;
                p3.ParameterName = "P_EVENT_TYPE_ID";
                p3.Value = 0;

                var p4 = cmd.CreateParameter();
                p4.Direction = System.Data.ParameterDirection.Input;
                p4.DbType = System.Data.DbType.String;
                p4.ParameterName = "P_EVENT_NAME";
                p4.Value = eventName;

                var p5 = cmd.CreateParameter();
                p5.Direction = System.Data.ParameterDirection.Input;
                p5.DbType = System.Data.DbType.String;
                p5.ParameterName = "P_EVENT_DATA";
                p5.Value = eventData;
                cmd.Parameters.AddRange(new []{ p1, p2, p3, p4, p5});
                cmd.CommandText = "`game_analytics`.`ADD_EVENT`";
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
