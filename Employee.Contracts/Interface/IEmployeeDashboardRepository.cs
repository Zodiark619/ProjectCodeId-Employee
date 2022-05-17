using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Employees.Contracts.Interface
{
    public interface IEmployeeDashboardRepository
    {
        Task<IEnumerable<EmployeePayHistory>> GetAllEmployeeAsync(bool trackChanges);
        Task<EmployeePayHistory> GetEmployeeAsync(string id, bool trackChanges);
        void CreateEmployeeAsync(EmployeePayHistory employee);
        void DeleteEmployeeAsync(EmployeePayHistory employee);
        void UpdateEmployeeAsync(EmployeePayHistory employee);
        //  Task<HashSet> GetPaginationCustomerAsync(EmployeesParameters employeesParameters, bool trackChanges, string choice, string order);
        Task<Dictionary<string, int>> ShowEmployeeDashboard1( bool trackChanges);
        
    }
}
