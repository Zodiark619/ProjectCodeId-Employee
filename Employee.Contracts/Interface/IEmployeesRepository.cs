using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Dto;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool trackChanges);
        Task<Employee> GetEmployeeAsync(string id, bool trackChanges);
        void CreateEmployeeAsync(Employee employee);
        void DeleteEmployeeAsync(Employee employee);
        void UpdateEmployeeAsync(Employee employee);

        //Task<IEnumerable<Customer>> GetPaginationCustomerAsync(CustomerParameters customerparameters, bool trackChanges);
    }
}
