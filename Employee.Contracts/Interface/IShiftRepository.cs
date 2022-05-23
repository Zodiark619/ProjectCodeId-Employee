using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Entities.Models;

namespace Employees.Contracts.Interface
{
    public interface IShiftRepository
    {
        Task<IEnumerable<Shift>> GetAllEmployeeAsync(bool trackChanges);
        Task<Shift> GetEmployeeAsync(byte id, bool trackChanges);
        void CreateEmployeeAsync(Shift employee);
        void DeleteEmployeeAsync(Shift employee);
        void UpdateEmployeeAsync(Shift employee);
        public Task<byte> GetShiftid(string name, bool trackChanges);

    }
}
