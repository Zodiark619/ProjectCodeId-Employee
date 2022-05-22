using Employees.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Contracts.Interface
{
    public interface IDepartmentsRepository
    {
        Task<IEnumerable<Department>> GetAllDepartments(bool trackChanges);
        Task<Department> GetDepartments(short id,bool trackChanges);
        void CreateDepartments(Department department);
        void UpdateDepartments(Department department);
        void DeleteDepartments(Department department);
    }
}
