using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApiAssigmnment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "myroute",
               url: "{controller}/{action}/{param}/{id}",
               defaults: new { controller = "Home", action = "Index", param = UrlParameter.Optional ,id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "myroute1",
               url: "{controller}/{action}/{id}/{date}",
               defaults: new { controller = "Home", action = "Index", date = UrlParameter.Optional, id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "myroute2",
               url: "{controller}/{action}/{id}/{date}/{status}",
               defaults: new { controller = "Home", action = "Index", date = UrlParameter.Optional, status=UrlParameter.Optional,id = UrlParameter.Optional }
           );
        }
    }
}
