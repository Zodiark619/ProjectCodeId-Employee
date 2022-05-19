using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface.IAddEditEmployeeRepository
{
    public interface IAddEditEmployeeRepository
    {
        Task<IEnumerable<AddEditEmployee2>> GetAllEmployeeAsync(bool trackChanges);
        Task<AddEditEmployee2> GetEmployeeAsync(int id, bool trackChanges);
        void CreateEmployeeAsync(AddEditEmployee2 employee);
        void DeleteEmployeeAsync(AddEditEmployee2 employee);
        void UpdateEmployeeAsync(AddEditEmployee2 employee);
    }
}
