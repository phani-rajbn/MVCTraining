using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private List<string> allEmployees = new List<string>
            {
                "Arun","Santosha","Muthu","Sanjay","Jagadish","Harish","Naren", "Jeevan", "Darshan","Shreyas","Aditya"
            };
        public List<string> GetAllEmployees()
        {
            return allEmployees;
        }
        public string GetEmployee(string id)
        {
            int no = int.Parse(id);
            if (no >= allEmployees.Count)
                return "Invalid No";
            return allEmployees[no];
        }
    }
}
