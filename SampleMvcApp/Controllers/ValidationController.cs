using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class ValidationController : Controller
    {
        private string msg;
        public ValidationController(string message)
        {
            msg = message;
        }
        public ViewResult TestView()
        {
            return new ViewResult();
        }
        public ValidationController() : this("Welcome123")
        {

        }
        // GET: Validation
        public ActionResult Index()
        {
            Student data = new Student();
            return View(data);
        }

        public ActionResult AddStudent(Student std)
        {
            if (ModelState.IsValid)
            {
                ViewBag.CurrentStudent = std;
            }
            else
                ViewBag.ErrorMessage = "Invalid Student";
            return View("Index");
        }
        /*There are 4 ways in which data is transfered from the controller to the View
         * Model Object: Any View can be strongly typed to a Model that can be transfered from the controller to the View. 
         * ViewBag: A dynamic object that stores the data in the form of key-value pairs. As the type is dynamic, intellisense would not be supported and Data binding happens at runtime
         * ViewData is a dictionary that stores the info in the form of object. Internally both ViewBag and ViewData are same. They are dictionary objects and are pointing to the same object
         * TempData: They are similar to ViewData except that Tempdata can be retained among the action methods. ViewBag and ViewData are associated within the Action. Other Action methods cannot access the info provided by these components
         */
        public ActionResult DisplayAll()
        {
            ViewBag.Records = new List<Student>
            {
                new Student { Age= 24, EmailAddress="s1@stu.edu", Name="Shiva" },
                new Student { Age= 22, EmailAddress="s2@stu.edu", Name="Amar" },
                new Student { Age= 23, EmailAddress="s3@stu.edu", Name="Vishnu" },
                new Student { Age= 23, EmailAddress="s4@stu.edu", Name="Shankar" },
                new Student { Age= 22, EmailAddress="s5@stu.edu", Name="Anant" },
                new Student { Age= 22, EmailAddress="s6@stu.edu", Name="Jagadish" },
                new Student { Age= 23, EmailAddress="s7@stu.edu", Name="Sumana" },
                new Student { Age= 23, EmailAddress="s8@stu.edu", Name="Kumari" },
                new Student { Age= 22, EmailAddress="s9@stu.edu", Name="Gayathri" }
            };
            ViewData["Courses"] = new List<string>
            {
                "B.Sc","M.Sc","B.Com","B.A","B.Lit","B.PE","B.Ed"
            };
            return View();//No data is sent thro model...
        }

        public ActionResult AddCourse(string Name, string Email, string Age, string Course)
        {
            if(HttpContext.Application["Courses"] == null)
            {
                HttpContext.Application["Courses"] = new Dictionary<string, string>();
            }
            Dictionary<string, string> courses = HttpContext.Application["Courses"] as Dictionary<string, string>;
            courses[Name] = Course;
            HttpContext.Application["Courses"] = courses;//reset to Application..
            TempData["EnrolledStudents"] = courses;//Putting it in TempData...
            TempData.Keep("EnrolledStudents");//The Key is retained in Dictionary...
            return RedirectToAction("DisplayAll");    
        }
    }
    
}