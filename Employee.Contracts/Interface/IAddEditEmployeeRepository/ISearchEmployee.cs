using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;

namespace Employees.Contracts.Interface.IAddEditEmployeeRepository
{
    public interface ISearchEmployee
    {
        Task<IEnumerable<Person>> GetAllEmployeeAsync(bool trackChanges);
        Task<Person> GetEmployeeAsync(int id, bool trackChanges);
        void CreateEmployeeAsync(Person employee);
        void DeleteEmployeeAsync(Person employee);
        void UpdateEmployeeAsync(Person employee);
        Task<IEnumerable<Person>> GetPaginationEmployeeAsync(EmployeesParameters employeesParameters, bool trackChanges);
    }
}
