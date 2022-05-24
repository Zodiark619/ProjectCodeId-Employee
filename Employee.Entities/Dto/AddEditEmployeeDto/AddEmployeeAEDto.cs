using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities.Dto.AddEditEmployeeDto
{
    public class AddEmployeeAEDto
    {
        public string LoginId { get; set; }
        public bool SalariedFlag { get; set; }
        public bool CurrentFlag { get; set; }
        public System.Guid Rowguid { get; set; }

        public int BusinessEntityId { get; set; }
        public string NationalIdnumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }



        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
  //      [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }


        public decimal Rate { get; set; }

        public int PayFrequency { get; set; }


        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string Shift { get; set; }
    }
}
