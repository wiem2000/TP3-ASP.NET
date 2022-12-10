using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace asp_tp3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "All",
               url: "Person/all",
               new { controller = "Person", action = "all" }

               );
            routes.MapRoute(
               name: "Search",
               url: "Person/search",
               new { controller = "Person", action = "FormSearch" }

               );
            routes.MapRoute(
            name: "Searching",
            url: "Person/PersonSearch",
            new { controller = "Person", action = "PersonSearch" }

            );

            routes.MapRoute(
                name: "GetPerson",
                url: "Person/{id}",
                new { controller = "Person", action = "ById" }
               
                );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}
