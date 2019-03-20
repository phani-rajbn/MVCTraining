using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class MathController : Controller
    {
        //Action is a  method that will invoked when client makes a request to this function thro URL routing...
        public ActionResult Index()
        {
            return View();
        }
    }
}