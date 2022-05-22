using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface
{
    public interface IEmployeeDepartmentHistoryRepository
    {
        Task<IEnumerable<EmployeeDepartmentHistory>> GetAllEmployeeAsync(bool trackChanges);
        Task<EmployeeDepartmentHistory> GetEmployeeAsync(int id, bool trackChanges);
        void CreateEmployeeAsync(EmployeeDepartmentHistory employee);
        void DeleteEmployeeAsync(EmployeeDepartmentHistory employee);
        void UpdateEmployeeAsync(EmployeeDepartmentHistory employee);
    }
}
