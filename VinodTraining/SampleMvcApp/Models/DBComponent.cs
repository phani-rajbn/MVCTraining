using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    //DAL Component that contains all the CRUD operations...
    public class DBComponent
    {
        public List<Employee> GetAllEmployees()
        {
            var context = new EmployeeDataContext();
            return context.Employees.ToList();
        }

        public Employee FindEmployee(int id)
        {
            var context = new EmployeeDataContext();
            var rec = context.Employees.FirstOrDefault(e => e.EmpID == id);
            if (rec == null)
                throw new Exception("Employee not found");
            return rec;
        }

        public void AddEmployee(Employee emp)
        {
            var context = new EmployeeDataContext();
            context.Employees.InsertOnSubmit(emp);//add to the ORM...
            context.SubmitChanges();//commit
        }

        public void UpdateEmployee(Employee emp)
        {
            var context = new EmployeeDataContext();
            var rec = context.Employees.FirstOrDefault(e => e.EmpID == emp.EmpID);
            if (rec == null)
                throw new Exception("Employee not found to update");
            rec.EmpName = emp.EmpName;
            rec.EmpAddress = emp.EmpAddress;
            rec.EmpSalary = emp.EmpSalary;
            context.SubmitChanges();//Commit the modified data...
        }

        public void DeleteEmployee(int id)
        {
            var context = new EmployeeDataContext();
            var rec = context.Employees.FirstOrDefault(e => e.EmpID == id);
            if (rec == null)
                throw new Exception("Employee not found to delete");
            context.Employees.DeleteOnSubmit(rec);
            context.SubmitChanges();
        }
    }
}