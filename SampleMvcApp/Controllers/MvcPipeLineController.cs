using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMvcApp.Infrastructure;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class MvcPipeLineController : CustomController
    {
        public MvcPipeLineController() : base()
        {
            
        }

        public ActionResult Index()
        {
            ViewResult res = new ViewResult();
            res.View = res.ViewEngineCollection.FindView(ControllerContext, "Index", null).View;
            res.ViewBag.Data = new string[]
            {
                "Apple","Mango","Orange"
            };
            return res;
        }

        public ContentResult AllEmployees()
        {
            string content = "<h1>Welcome to MVC PipeLine</h1>";
            ContentResult result = new ContentResult();
            result.Content = content;
            return result;
        }

        
    }
}