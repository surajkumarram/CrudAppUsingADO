using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudAppUsingADO.Models
{
    public class EmployeeClass1
    {
        public int id { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Degination { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Salary { get; set; }
        public bool isActive { get; set; }
    }
}