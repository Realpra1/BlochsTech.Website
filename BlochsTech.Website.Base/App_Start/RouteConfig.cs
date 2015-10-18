using System.Web.Mvc;
using System.Web.Routing;

namespace BlochsTech.Website.Base
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Buy", action = "Index" }
            );

            routes.MapRoute(
                name: "TerminalApps",
                url: "apps",
                defaults: new { controller = "Home", action = "TerminalApps" }
            );

            routes.MapRoute(
                name: "Info",
                url: "info",
                defaults: new { controller = "Home", action = "Info" }
            );

            routes.MapRoute(
                name: "Company",
                url: "company",
                defaults: new { controller = "Home", action = "Company" }
            );

            routes.MapRoute(
                name: "Thankyou",
                url: "thankyou",
                defaults: new { controller = "Home", action = "Thankyou" }
            );

            routes.MapRoute(
                name: "PaypalIPN",
                url: "paypalipn",
                defaults: new { controller = "Home", action = "PaypalIpn" }
            );

            routes.MapRoute(
                name: "CatchAll",
                url: "{*path}",
                defaults: new { controller = "Home", action = "Go" }
            );
        }
    }
}
