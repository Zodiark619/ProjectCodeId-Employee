using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface
{
    public interface IEmployeeDashboard1Repository
    {
        Task<IEnumerable<VEmployeeDepartment>> GetAllEmployeeAsync(bool trackChanges);
        Task<VEmployeeDepartment> GetEmployeeAsync(string id, bool trackChanges);
        void CreateEmployeeAsync(VEmployeeDepartment employee);
        void DeleteEmployeeAsync(VEmployeeDepartment employee);
        void UpdateEmployeeAsync(VEmployeeDepartment employee);
        //  Task<HashSet> GetPaginationCustomerAsync(EmployeesParameters employeesParameters, bool trackChanges, string choice, string order);
        Task<Dictionary<string, int>> ShowEmployeeDashboard1(bool trackChanges);
    }
}
