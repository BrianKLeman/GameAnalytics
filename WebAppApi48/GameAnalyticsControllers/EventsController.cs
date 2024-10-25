using DataAccessLayer;
using DataAccessLayer.GameAnalyticsRepository;
using System.Web.Http;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{

    public class Event
    {
        public int gameID { get; set; }
        public string eventTypeName { get; set; }
        public string eventData { get; set; }
        public string userID { get; set; }
    }
    [RoutePrefix("Api/Events")]
    public class EventsController : ApiController
    {
        public EventsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.eventsDataAccess = Resolver.Current.GetService(typeof(IEventsDataAccess)) as IEventsDataAccess;
        }

        private IAuthService authService;
        private  IEventsDataAccess eventsDataAccess;
        public IHttpActionResult Post([FromBody]Event ev)
        {
            eventsDataAccess.AddEvent(ev.gameID, ev.eventTypeName, ev.userID, ev.eventData);

            return Ok();
        }

       

    }
}