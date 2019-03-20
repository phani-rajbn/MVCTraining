using SampleMvcApp.Models;//For DBCOmponent .....
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult AllEmployees()
        {
            var com = new DBComponent();
            var model = com.GetAllEmployees();
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var com = new DBComponent();
            int empId = int.Parse(id);
            var model = com.FindEmployee(empId);
            return View(model);
        }

        [HttpPost]//As there are 2 methods, we should differ them by the HTTP Method....
        public ActionResult Edit(Employee emp)
        {
            var com = new DBComponent();
            com.UpdateEmployee(emp);
            return RedirectToAction("AllEmployees");//Redirecting to the Table View...
        }

        public ActionResult AddNew()
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult AddNew(Employee emp)
        {
            var com = new DBComponent();
            com.AddEmployee(emp);
            return RedirectToAction("AllEmployees");
        }
        public ActionResult Delete(int id)
        {
            var com = new DBComponent();
            com.DeleteEmployee(id);
            return RedirectToAction("AllEmployees");
        }
    }
}