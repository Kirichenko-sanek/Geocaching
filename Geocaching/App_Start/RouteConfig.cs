using System.Web.Mvc;
using System.Web.Routing;

namespace Geocaching
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AfterRegistration",
                url: "Account/EndRegistration",
                defaults: new {controller = "Account", action = "EndRegistration"}
                );

            routes.MapRoute(
                name: "ConfirmEmail",
                url: "Account/ConfirmEmail",
                defaults: new {controller = "Account", action = "ConfirmEmail"}
                );

            routes.MapRoute(
                name: "AddCache",
                url: "Cache/AddCache",
                defaults: new {controller = "Cache", action = "AddCache"}
                );

            routes.MapRoute(
                name: "EndPassRecovery",
                url: "Account/EndPassRecovery",
                defaults: new {controller = "Account", action = "EndPassRecovery"}
                );

            routes.MapRoute(
                name: "EndRecoveryProfile",
                url: "Account/EndRecoveryProfile",
                defaults: new { controller = "Account", action = "EndRecoveryProfile" }
                );

            routes.MapRoute(
                name: "UserPage",
                url: "Profile/UserPage/{id}",
                defaults: new {controller = "Profile", action = "UserPage", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "EditProfile",
                url: "Profile/EditProfile/{id}",
                defaults: new {controller = "Profile", action = "EditProfile", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "CachePage",
                url: "Cache/CachePage/{id}",
                defaults: new {controller = "Cache", action = "CachePage", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}
