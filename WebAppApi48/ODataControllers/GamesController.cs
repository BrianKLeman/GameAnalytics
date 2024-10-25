using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Linq;
using Microsoft.AspNet.OData;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
using System.Web.Http;
using System.Threading.Tasks;
using DataAccessLayer.GameAnalyticsRepository;
using DataAccessLayer.GameAnalytics;

namespace WebAppApi48.OData.GameAnalytics.Controllers
{
    public class GamesController : ODataController
    {
        public GamesController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.repo = new GamesODataRepository<Games>();
        }

        private IAuthService authService;
        private GamesODataRepository<Games> repo = null;

        private bool GameExists(int key)
        {
            var personID = this.authService.VerifyCredentials(Request);  
            return repo.Get().Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Games> Get()
        {
            return repo.Get();           
        }
        
        [EnableQuery]        
        public SingleResult<Games> Get([FromODataUri] int key)
        {            
            IQueryable<Games> result = repo.Get().Where( x=> x.Id == key);
            return SingleResult.Create(result);
        }
        /*
        public async Task<IHttpActionResult> Put([FromODataUri] int key, ShoppingItems update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 0)
                return this.Unauthorized();            

            await this.repo.Update(personID, update);
            
            return Updated(update);
        }
        */
    }
}