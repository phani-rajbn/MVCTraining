using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.qpServices;
namespace SampleMvcApp.Controllers
{
    public class QuestionController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult NewQuestion()
        {
            //When a service is referenced, all collection class objects will be defaulted to Array....
            var question = new QuestionInfo();
            question.Options = new string[4];
            //QuestionInfo is the datacontract class of the service...
            return View(question);
        }
        [HttpPost]
        public ActionResult NewQuestion(QuestionInfo info)
        {
            var service = new QuestionServiceClient();
            service.AddQuestion(info);
            return RedirectToAction("Greeting", "FirstExample");
        }
    }
}