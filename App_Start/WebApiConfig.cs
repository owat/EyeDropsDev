using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EyeDropsDev
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "api/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);
            config.Routes.MapHttpRoute(
name: "LogoffApi",// Route name
routeTemplate: "api/{controller}/{action}/{lout}",                           // URL with parameters
    defaults: new { controller = "MAccount", action = "Logout", lout="" }
);

            config.Routes.MapHttpRoute(
name: "LogchkApi",// Route name
routeTemplate: "api/{controller}/{action}/{ion}",                           // URL with parameters
defaults: new { controller = "MAccount", action = "Ison", ion = "" }
);
            config.Routes.MapHttpRoute(
    name: "LusrApi",
    routeTemplate: "api/{controller}/{action}/{lusr}",
    defaults: new { controller = "MAccount", action = "Today", lusr ="" }
);

            config.Routes.MapHttpRoute(
                name: "LoginApi",// Route name
                routeTemplate: "api/{controller}/{action}/{username}/{password}",                           // URL with parameters
                defaults: new { controller = "MAccount", action = "Login", username = "", password = "" }  // Parameter defaults
        );

        }
    }
}
