using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Entities.Dto
{
    public class EmployeesDto
    {
        
        public string JobTitle { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
    }
}
