using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GameAnalyticsRepository
{
    public interface IEventsDataAccess
    {
        int AddEvent(int gameId, string eventName, string userGuid, string eventData);
    }
}
