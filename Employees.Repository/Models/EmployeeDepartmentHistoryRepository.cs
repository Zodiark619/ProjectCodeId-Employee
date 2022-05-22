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
    public class EmployeeDepartmentHistoryRepository : RepositoryBase<EmployeeDepartmentHistory>, IEmployeeDepartmentHistoryRepository
    {
        public EmployeeDepartmentHistoryRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(EmployeeDepartmentHistory employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(EmployeeDepartmentHistory employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<EmployeeDepartmentHistory>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<EmployeeDepartmentHistory> GetEmployeeAsync(int id, bool trackChanges)
        =>
            await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges)
            .OrderByDescending(c => c.ModifiedDate)
                .FirstOrDefaultAsync();

        public void UpdateEmployeeAsync(EmployeeDepartmentHistory employee)
        {
            Update(employee);
        }
    }
}
