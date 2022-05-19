using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface.IAddEditEmployeeRepository
{
    public interface IAddEditEmployeeRepository2
    {
        Task<IEnumerable<AddEditEmployee3>> GetAllEmployeeAsync(bool trackChanges);
        Task<IEnumerable<AddEditEmployee3>> GetEmployeeAsync(int id, bool trackChanges);
        void CreateEmployeeAsync(AddEditEmployee3 employee);
        void DeleteEmployeeAsync(AddEditEmployee3 employee);
        void UpdateEmployeeAsync(AddEditEmployee3 employee);
    }
}
