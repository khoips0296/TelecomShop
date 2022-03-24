using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TelecomShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Category Pack",
                url: "Category/Pack/{id}",
                defaults: new { controller = "Category", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Category Product",
                url: "Category/Product/{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );


            routes.MapRoute(
                name: "Pack Details",
                url: "{catName}/Pack/{id}",
                defaults: new { controller = "Pack", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Product Details",
                url: "{catName}/Product/{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart Product",
                url: "Add-Cart-Product",
                defaults: new { controller = "Cart", action = "AddItemProduct", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart Pack",
                url: "Add-Cart-Pack",
                defaults: new { controller = "Cart", action = "AddItemPack", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "Cart",
                defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Payment",
                url: "Payment",
                defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Blog",
                url: "Blog",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );
            routes.MapRoute(
                name: "Blog- Detail",
                url: "Blog/{id}",
                defaults: new { controller = "Blog", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TelecomShop.Controllers" }
            );
        }
    }
}
