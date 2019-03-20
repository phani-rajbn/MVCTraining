using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult AllEmployees()
        {
            var obj = new DBComponent();
            var model = obj.GetAllEmployees();
            return View(model);
        }

        //Called when the User clicks the More Link in the View....
        public ActionResult Edit(string id)
        {
            var obj = new DBComponent();//Create UR DBComponent object
            int empid = int.Parse(id);//Convert string id to int empid
            var selected = obj.GetAllEmployees().FirstOrDefault(e => e.EmpID == empid);//find the employee by id...
            var depts = obj.GetAllDepts().Select(e => new SelectListItem { Text = e.DeptName, Value = e.DeptId.ToString() }).ToList();
            //Get all Depts from the source and convert it to List<SelectListItem> to use it inside DropDownList....
            ViewBag.Depts = depts;//Add it to ViewBag object to display in the view...
            if(selected == null)
            {
                Response.Write("No Employee found to edit");
            }
            return View(selected);//Render the View with selected emp as injection...
        }
        [HttpPost]
        public ActionResult Edit(EmpTable emp)
        {
            var obj = new DBComponent();
            obj.UpdateEmployee(emp);
            return RedirectToAction("AllEmployees");//Moves the code to the Action AllEmployees...
        }

        public ActionResult AddNew()
        {
            var obj = new DBComponent();
            var depts = obj.GetAllDepts().Select(e => new SelectListItem { Text = e.DeptName, Value = e.DeptId.ToString() }).ToList();
            //Get all Depts from the source and convert it to List<SelectListItem> to use it inside DropDownList....
            ViewBag.Depts = depts;//Add it to ViewBag object to display in the view...
            return View(new EmpTable());
        }
        [HttpPost]
        public ActionResult AddNew(EmpTable emp)
        {
            var obj = new DBComponent();
            obj.AddNewEmployee(emp);
            return RedirectToAction("AllEmployees");
        }

        public ActionResult Delete(string id)
        {
            ViewData["Error"] = "";//Initialize it to ""
            var obj = new DBComponent();
            int empid = int.Parse(id);
            try
            {
                obj.DeleteEmployee(empid);
            }
            catch(Exception ex)
            {
                ViewData["Error"] = ex.Message;//set the error message
            }
            return View("AllEmployees", obj.GetAllEmployees());
            //ViewData is another way of sharing data to the View. ViewData is a  dictionary object where data is stored as KEY-VALUE pairs...
        }
    }
}