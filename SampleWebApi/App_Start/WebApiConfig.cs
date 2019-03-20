using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SampleWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();//Step2: call the EnableCors function....
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller ="EmpService", id = RouteParameter.Optional }
            );
        }
    }
}
