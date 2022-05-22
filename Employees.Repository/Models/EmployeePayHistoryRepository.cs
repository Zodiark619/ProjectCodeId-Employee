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
    public class EmployeePayHistoryRepository : RepositoryBase<EmployeePayHistory>, IEmployeePayHistoryRepository
    {
        public EmployeePayHistoryRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(EmployeePayHistory employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(EmployeePayHistory employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<EmployeePayHistory>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<EmployeePayHistory> GetEmployeeAsync(int id, bool trackChanges)
         =>
            await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges)
                .OrderByDescending(c=>c.ModifiedDate)
                .FirstOrDefaultAsync();

        public void UpdateEmployeeAsync(EmployeePayHistory employee)
        {
            Update(employee);
        }
    }
}
