using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface.IAddEditEmployeeRepository
{
    public interface IAddEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool trackChanges);
        Task<Employee> GetEmployeeAsync(int id, bool trackChanges);
        void CreateEmployeeAsync(Employee employee);
        void DeleteEmployeeAsync(Employee employee);
        void UpdateEmployeeAsync(Employee employee);
        
    }
}
