using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities.Dto.AddEditEmployeeDto
{
    public class SearchEmployeeAEDto
    {
        public int BusinessEntityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string PersonType { get; set; }
      //  public string FullName { get; set; } = FirstName + " " + LastName;
    }
}
