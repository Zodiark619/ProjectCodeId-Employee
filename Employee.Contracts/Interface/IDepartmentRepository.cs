using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllEmployeeAsync(bool trackChanges);
        Task<Department> GetEmployeeAsync(byte id, bool trackChanges);
        void CreateEmployeeAsync(Department employee);
        void DeleteEmployeeAsync(Department employee);
        void UpdateEmployeeAsync(Department employee);
        public Task<Department> GetDepartment(byte id, bool trackChanges);
    }
}
