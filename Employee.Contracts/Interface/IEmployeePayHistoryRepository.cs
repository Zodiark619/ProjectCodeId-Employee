using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface
{
    public interface IEmployeePayHistoryRepository
    {
         Task<IEnumerable<EmployeePayHistory>> GetAllEmployeeAsync(bool trackChanges);
         Task<EmployeePayHistory> GetEmployeeAsync(int id, bool trackChanges);
        void CreateEmployeeAsync(EmployeePayHistory employee);
        void DeleteEmployeeAsync(EmployeePayHistory employee);
        void UpdateEmployeeAsync(EmployeePayHistory employee);
    }
}
