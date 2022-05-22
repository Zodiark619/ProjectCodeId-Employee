using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities.Dto.AddEditEmployeeDto
{
    public class AddDto
    {
        /*public int BusinessEntityID { get; set; }
     // public string FullName { get; set; }
        public string NationalIDNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime HireDate { get; set; }
        public Double Rate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int PayFrequency { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }*/

        /*[ForeignKey(nameof(DepartmentId))]
         public int DepartmentId { get; set; }

         public AddEditEmployeeDto2 AddEditEmployeeDto2 { get; set; }*/
        [Key]
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


    }
}
