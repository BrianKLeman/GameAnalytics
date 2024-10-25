using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GameAnalyticsRepository
{
    public interface IHeatmapsDataAccess
    {
        int AddHeatmap(int gameId, string heatmap, string sessionId, string userGuid, string sceneName);

        IEnumerable<string> GetSessions(int gameId, string sceneName);
    }
}
