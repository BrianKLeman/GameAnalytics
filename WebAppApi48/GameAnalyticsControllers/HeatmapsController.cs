using DataAccessLayer;
using DataAccessLayer.GameAnalyticsRepository;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{

    public class Heatmap
    {
        [Required]
        public int gameID { get; set; }
        [Required]
        public string sessionID { get; set; }

        [Required]
        public string heatmap { get; set; }
        [Required]
        public string userID { get; set; }

        [Required]
        public string sceneName { get; set; }
    }
    [RoutePrefix("Api/Heatmaps")]
    public class HeatmapsController : ApiController
    {
        public HeatmapsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.heatmapsDataAccess = Resolver.Current.GetService(typeof(IHeatmapsDataAccess)) as IHeatmapsDataAccess;
        }

        private IAuthService authService;
        private  IHeatmapsDataAccess heatmapsDataAccess;
        public IHttpActionResult Post([FromBody]Heatmap ev)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            heatmapsDataAccess.AddHeatmap(ev.gameID, ev.heatmap, ev.sessionID, ev.userID, ev.sceneName);
            
            return Ok();
        }
        
    }
}