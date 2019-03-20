using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;

//Controller in MVC is a class that implements an interface called IController or derived from a Class called System.Web.Mvc.Controller. 
namespace SampleMvcApp.Controllers
{
    //URController->Controller->ControllerBase->IController
    public class FirstExampleController : Controller
    {
        public string Greeting()
        {
            string data = "Hello World";
            return data;
        }   

        public ViewResult CurrentQuestion()
        {
            QuestionInfo info =  new QuestionInfo
            {
                Question = "Which of these is the base class for all Types in .NET",
                QuestionNo = 1,
                Options = new List<string>
                {
                    "System.Runtime.Text",
                    "System.Object",
                    "System.Class.Reference",
                    "System.BaseClass"
                },
                RightAnswer = 2
            };
            return View(info);//Injecting the Model into the View....
        }
    }
}