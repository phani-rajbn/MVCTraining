using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SampleMvcApp.Models
{
    //DataAnotations are the way of Validating MVC models where every property is set with attributes that define validations for the model objects. 
    public class Student
    {
        [Required(ErrorMessage ="Name is mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Age is mandatory")]
        [Range(18,40,ErrorMessage ="Age should be within 18 to 40")]
        public int Age { get; set; }
        [Required(ErrorMessage = "EMail is mandatory")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string EmailAddress { get; set; }
    }
}