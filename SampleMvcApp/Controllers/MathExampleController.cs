using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class MathExampleController : Controller
    {
        //Action called thro HTTPGET
        public ActionResult Home()
        {
            return View(0.0);
        }

        [HttpPost]
        public ActionResult Home(string FirstValue, string SecondValue, string Operation)
        {
            //A View can be associated with only one type of model.
            ViewBag.Apple = true;
            ViewBag.Name = "Phaniraj";
            ViewBag.Address = "RR Nagar" ;
            //ViewBag is a dynamic object that allows to send data of any kind to the View other than the model. ViewBag being a Dynamic object, will not support intellisense and it internally behaves like a Dictionary in the form key-Value pairs.... 
            double result = 0;
            switch (Operation)
            {
                case "+":
                    result = double.Parse(FirstValue) + double.Parse(SecondValue);
                    break;
                case "-":
                    result = double.Parse(FirstValue) - double.Parse(SecondValue);
                    break;

                case "X":
                    result = double.Parse(FirstValue) * double.Parse(SecondValue);
                    break;
                case "/":
                    result = double.Parse(FirstValue) / double.Parse(SecondValue);
                    break;
            }
            return View(result);//Model is a double...
        }
    }
}