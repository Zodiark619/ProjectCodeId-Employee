using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees.Entities.Dto.AddEditEmployeeDto
{
    public class AddEditEmployeeDto2
    {
       // [Column("DepartmentId")]
        public int BusinessEntityID { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Shift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }



        //AddEditEmployee3
        //public virtual IList<AddEditEmployeeDto> Departments { get; set; }
    }
}
