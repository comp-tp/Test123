using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Accela.Apps.Apis.Services.Host
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Apis-help",
                url: "apis-help/{controller}/{action}/{id}",
                defaults: new { controller = "Apis", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               "A311ImageDefault", // Route name
               "A311/{controller}/{action}/{id}", // URL with parameters
               new { controller = "Images", action = "Get", id = UrlParameter.Optional } // Parameter defaults
           );

           routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
             );
        }
    }
}