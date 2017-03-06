using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.EnableSystemDiagnosticsTracing();
            configuration.Routes.MapHttpRoute(
    name: "ControllerOnly",
    routeTemplate: "api/{controller}"
);

            // Controller with ID
            // To handle routes like `/api/VTRouting/1`
            configuration.Routes.MapHttpRoute(
                name: "ControllerAndId",
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" } // Only integers 
            );

            // Controllers with Actions
            // To handle routes like `/api/VTRouting/route`
            configuration.Routes.MapHttpRoute(
                name: "ControllerAndAction",
                routeTemplate: "api/{controller}/{action}"
            );

        }
    }
}
