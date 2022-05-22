using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Employees.Entities.Models
{
    public partial class AddEditEmployee3
    {
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Shift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


      /*  [ForeignKey(nameof(BusinessEntityId))]
        public int BusinessEntityId { get; set; }

        public AddEditEmployee2 AddEditEmployee2 { get; set; }*/

    }
}
