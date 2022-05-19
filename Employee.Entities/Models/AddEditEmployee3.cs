using System;
using System.Collections.Generic;

#nullable disable

namespace Employees.Entities.Models
{
    public partial class AddEditEmployee3
    {
        public int BusinessEntityId { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Shift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // public virtual ICollection<AddEditEmployee2> Departments { get; set; }
    }
}
