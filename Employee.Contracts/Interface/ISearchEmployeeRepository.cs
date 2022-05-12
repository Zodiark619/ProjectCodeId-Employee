using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;

namespace Employees.Contracts.Interface
{
    public interface ISearchEmployeeRepository
    {
        Task<IEnumerable<SearchEmployee>> GetAllEmployeeAsync(bool trackChanges);
        Task<SearchEmployee> GetEmployeeAsync(string id, bool trackChanges);
        void CreateEmployeeAsync(SearchEmployee employee);
        void DeleteEmployeeAsync(SearchEmployee employee);
        void UpdateEmployeeAsync(SearchEmployee employee);
        Task<IEnumerable<SearchEmployee>> GetPaginationCustomerAsync(EmployeesParameters employeesParameters, bool trackChanges);
    }
}
