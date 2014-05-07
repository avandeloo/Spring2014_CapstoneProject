using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnvironmentalApp.Gui
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index2", id = UrlParameter.Optional });
           
            routes.MapPageRoute("Report", "Report", "~/Views/Report/Index.chtml");
            //     routes.MapRoute(
            //    name: "Report",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Report", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}