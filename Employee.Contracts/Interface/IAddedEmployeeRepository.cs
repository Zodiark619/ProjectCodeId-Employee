using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;

namespace Employees.Contracts.Interface
{
    public interface IAddedEmployeeRepository
    {
        Task<IEnumerable<VAddedEmployee>> GetAllVAddedEmployeeAsync(bool trackChanges);
        Task<VAddedEmployee> GetVAddedEmployeeAsync(string id, bool trackChanges);
        void CreateVAddedEmployeeAsync (VAddedEmployee vAddedEmployee);
        void UpdateVAddedEmployeeAsync (VAddedEmployee vAddedEmployee);
        void DeleteVAddedEmployeeAsync (VAddedEmployee vAddedEmployee);
        Task<IEnumerable<VAddedEmployee>> GetPaginationVAddedEmployeeAsync(EmployeesParameters employeesParameters, bool trackChanges);

    }
}
