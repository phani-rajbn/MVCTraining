using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class AjaxController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //create the view as partial view...
        public PartialViewResult Latest()
        {
            var data = HttpContext.Application["Articles"] as Queue<Article>;
            var dataList = data.ToList();
            return PartialView(dataList); 
        }

        public PartialViewResult Details(string id)
        {
            var data = HttpContext.Application["Articles"] as Queue<Article>;
            var find = data.FirstOrDefault(d => d.Heading == id);
            return PartialView(find);
        }
        //Actionresult is the base class for all kinds of results in MVC. its advised to use the base class object as the return type.
        public ActionResult AddNew()
        {
            var blank = new Article();
            blank.PublishedOn = DateTime.Now;
            return PartialView(blank);
        }
        [HttpPost]
        public ActionResult AddNew(Article newArticle)
        {
            var data = HttpContext.Application["Articles"] as Queue<Article>;
            data.Enqueue(newArticle);
            HttpContext.Application["Articles"] = data;
            var list = data.Reverse().ToList();
            return PartialView("Latest", list);
        }
    }
}