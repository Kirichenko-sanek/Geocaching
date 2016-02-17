﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                defaults: new { controller = "Account", action = "EndRegistration" }
            );

            routes.MapRoute(
               name: "ConfirmEmail",
               url: "Account/ConfirmEmail",
               defaults: new { controller = "Account", action = "ConfirmEmail" }
           );

            routes.MapRoute(
               name: "EndPassRecovery",
               url: "Account/EndPassRecovery",
               defaults: new { controller = "Account", action = "EndPassRecovery" }
           );

            routes.MapRoute(
               name: "UserPage",
               url: "Profile/UserPage/{id}",
               defaults: new { controller = "Profile", action = "UserPage", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}