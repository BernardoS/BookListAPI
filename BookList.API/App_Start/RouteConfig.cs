using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookList.API
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "GetSpecificBook",
                 url: "{controller}/GetBooks/{id}",
                 defaults: new { controller = "Book", action = "GetBook" }
             );
            routes.MapRoute(
                name: "UpdateSpecificBook",
                url: "{controller}/Update",
                defaults: new { controller = "Book", action = "UpdateBook" }
            );
            routes.MapRoute(
                name: "DeleteSpecificBook",
                url: "{controller}/Remove/{id}",
                defaults: new { controller = "Book", action = "Remove" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "GetBooks", id = UrlParameter.Optional }
            );
        }
    }
}
