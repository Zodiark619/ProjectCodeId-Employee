using System;
using System.Collections.Generic;

#nullable disable

namespace Employees.WebApi.Models
{
    public partial class SearchEmployee
    {
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
