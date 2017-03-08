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
                name: "Create",
                url: "{controller}/{action}",
                defaults: null,
                constraints: new { controller = "Products", action = "Create" }
            );

            routes.MapRoute(
                name: "ByTag",
                url: "{controller}/Tag-{tagName}",
                defaults: new { action = "GetProductsByTag" },
                constraints: new { controller = "Products", action = "GetProductsByTag" }
            );

            routes.MapRoute(
                name: "ByCategory",
                url: "{controller}/{category}",
                defaults: new { action = "GetProducts" },
                constraints: new { controller = "Products", action = "GetProducts" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
