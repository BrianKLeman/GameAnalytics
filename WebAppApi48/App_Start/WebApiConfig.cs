using System.Web.Http;
using DataAccessLayer.GameAnalytics;
using DataAccessLayer.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;

namespace WebAppApi48
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // OData
                
            // Game Analytics
            ODataModelBuilder odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Games>("Games");
            var edmModelGames = odataBuilder.GetEdmModel();
            config.MapODataServiceRoute(
                routeName: "ODataGamesRoute",
                routePrefix: "Odata/GameAnalytics",
                model: edmModelGames);
        }
    }
}
