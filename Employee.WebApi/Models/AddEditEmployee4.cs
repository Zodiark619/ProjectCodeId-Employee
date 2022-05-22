using System;
using System.Collections.Generic;

#nullable disable

namespace Employees.WebApi.Models
{
    public partial class AddEditEmployee4
    {
        public int BusinessEntityId { get; set; }
        public string NationalIdnumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Rate { get; set; }
        public DateTime PayModifiedDate { get; set; }
        public byte PayFrequency { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ShiftModifiedDate { get; set; }
        public string Shift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
