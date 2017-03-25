﻿using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop.Clients.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.LowercaseUrls = true;

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Basic", id = UrlParameter.Optional }
            );
        }
    }
}
