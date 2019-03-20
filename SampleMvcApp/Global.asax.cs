using SampleMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SampleMvcApp.Infrastructure;
namespace SampleMvcApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        [CustomExceptionFilter]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());//To set the Custom Controller Factory....

            var data = NewsArticleManager.GetLatest();
            Queue<Article> sortedData = new Queue<Article>(data);
            Application.Add("Articles", sortedData);//create AppState variable... 
        }
    }
}
