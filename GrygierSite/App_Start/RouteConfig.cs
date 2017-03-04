using GrygierSite.Core.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace GrygierSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ByTag",
                url: "{controller}/{action}/{tagName}/{page}",
                defaults: new { controller = "Home", action = "Index", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ByCategory",
                url: "{controller}/{action}/{category}/{page}",
                defaults: new { controller = "Home", action = "Index", category = Categories.All, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
