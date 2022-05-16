using System;
using System.Collections.Generic;

#nullable disable

namespace Employees.Entities.Models
{
    public partial class VAddedEmployee
    {
        public int BusinessEntityId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string NationalIdnumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public decimal Rate { get; set; }
        public byte PayFrequency { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public string GroupName { get; set; }
        public string JobTitle { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
