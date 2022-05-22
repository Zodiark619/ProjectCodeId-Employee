using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models
{
    public class ShiftRepository : RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(Shift employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(Shift employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<Shift>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.ShiftId).ToListAsync();
        }

        public async Task<Shift> GetEmployeeAsync(byte id, bool trackChanges)
        =>
            await FindByCondition(c => c.ShiftId.Equals(id), trackChanges)


                .FirstOrDefaultAsync();

        public void UpdateEmployeeAsync(Shift employee)
        {
            Update(employee);
        }
    }
}
