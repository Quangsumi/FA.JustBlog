using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FA.JustBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Post",
                url: "Post/{year}/{month}/{urlslug}",
                defaults: new { controller = "Post", action = "Details"},
                new { year = @"\d{4}", month = @"\d{2}" },
                new[] { "FA.JustBlog.Controllers" }
            );

            routes.MapRoute(
                name: "Category",
                url: "Category/{urlslug}",
                defaults: new { controller = "Category", action = "Details" },
                new[] { "FA.JustBlog.Controllers" }
            );

            routes.MapRoute(
                name: "Tag",
                url: "Tag/{urlslug}",
                defaults: new { controller = "Tag", action = "Details" },
                new[] { "FA.JustBlog.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "FA.JustBlog.Controllers" }
            );

            routes.MapRoute(
                name: "Admin",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
                new[] { "FA.JustBlog.Areas.Admin.Controllers" }
            );
        }
    }
}
