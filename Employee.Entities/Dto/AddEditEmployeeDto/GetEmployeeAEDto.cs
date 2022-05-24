using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities.Dto.AddEditEmployeeDto
{
    public class GetEmployeeAEDto
    {
        public string FullName { get; set; }
        public string Suffix { get; set; }


        public string NationalIdnumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
      
        
      
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public DateTime ModifiedDate { get; set; }


        public decimal Rate { get; set; }
        
        public int PayFrequency { get; set; }


        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Shift { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

    }
}
