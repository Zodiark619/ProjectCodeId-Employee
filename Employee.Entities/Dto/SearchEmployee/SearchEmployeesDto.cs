using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Entities.Dto.SearchEmployee
{
    public class SearchEmployeesDto
    {
        //nationalid,firstname,lastname,email,phonecall,jobtitle,birthdate,hiredate,department
        /*[Required]
        public Employee NationalIDNumber { get; set; }
        [Required]
        public Person FirstName { get; set; }
        [Required]
        public Person LastName { get; set; }      
        public EmailAddress EmailAddress { get; set; }
        [Required]
        public PersonPhone PhoneNumber { get; set; } 
        [Required]
        public Employee JobTitle { get; set; }
        [Required]
        public Employee BirthDate { get; set; }
        [Required]
        public Employee HireDate { get; set; }
        [Required]
        public Department Name { get; set; }*/


        /*  [Required]
          public string NationalIDNumber { get; set; }
          [Required]
          public string FirstName { get; set; }
          [Required]
          public string LastName { get; set; }

          public string EmailAddress { get; set; }
          [Required]
          public string PhoneNumber { get; set; }
          [Required]
          public string JobTitle { get; set; }


          [Required]
          public DateTime BirthDate { get; set; }
          [Required]
          public DateTime HireDate { get; set; }
          [Required]
          public string Name { get; set; }*/



        public int BusinessEntityId { get; set; }
        public string NationalIdnumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Name { get; set; }
    }
}
