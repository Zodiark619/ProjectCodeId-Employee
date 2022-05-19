using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Employees.Entities.Models
{
    public partial class AddEditEmployee2
    {
        public int BusinessEntityId { get; set; }
        public string NationalIdnumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Rate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte PayFrequency { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }

       /* [ForeignKey(nameof("BusinessEntityId"))]
        public int BusinessEntityId { get; set; }
        public AddEditEmployee3 AddEditEmployee3 { get; set; }*/
    }
}
