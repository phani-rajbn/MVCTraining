using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Infrastructure;
/*
 * Filters are additional logic that U want to inject into the MVC pipeline for processing of the Request. Sometimes, we would like to perform things like validation, error Handling, Authentication, Authorization, log some info before the result is returned to the user and so forth...
 * MVC 5.0 has 5 Filters: Authentication, Authorization, Action, Result, Exception.
 * All these filters are attributes that are set at various levels of the Application: Controllers or Actions.  
 */
namespace SampleMvcApp.Controllers
{
    public class FilterController : Controller
    {
        //[OutputCache(Duration =60)]//BuiltIn Action Filter...
        [CustomAuthorizeFilter(true)]
        [CustomExceptionFilter()]
        public ActionResult Index()
        {
            DateTime dt = DateTime.Now;
                throw new Exception("My Own Exception");
//            return View(dt);
        }
    }
}