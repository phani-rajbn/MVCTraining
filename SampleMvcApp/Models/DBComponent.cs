using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class DBComponent
    {
        public List<EmpTable> GetAllEmployees()
        {
            var context = new EmpDBEntities();
            return context.EmpTables.ToList();
        }

        public List<DeptTable> GetAllDepts()
        {
            var context = new EmpDBEntities();
            return context.DeptTables.ToList();
        }

        public void AddNewEmployee(EmpTable emp)
        {
            var context = new EmpDBEntities();
            context.EmpTables.Add(emp);
            context.SaveChanges();
        }

        public void UpdateEmployee(EmpTable emp)
        {
            var context = new EmpDBEntities();
            var find = context.EmpTables.FirstOrDefault(e => e.EmpID == emp.EmpID);
            if (find == null)
                throw new Exception("No Employee found to update");
            find.EmpAddress = emp.EmpAddress;
            find.EmpName = emp.EmpName;
            find.EmpSalary = emp.EmpSalary;
            find.DeptID = emp.DeptID;
            context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var context = new EmpDBEntities();
            var find = context.EmpTables.FirstOrDefault(e => e.EmpID == id);
            if (find == null)
                throw new Exception("No Employee found to Delete");
            context.EmpTables.Remove(find);
            context.SaveChanges();
        }
    }
}