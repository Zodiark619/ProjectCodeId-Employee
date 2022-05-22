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
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(Department employee)
        {
          Create(employee);
        }

        public void DeleteEmployeeAsync(Department employee)
        {
           Delete(employee);
        }

        public async Task<IEnumerable<Department>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.DepartmentId).ToListAsync();
        }

        public async Task<Department> GetEmployeeAsync(byte id, bool trackChanges)
         =>
            await FindByCondition(c => c.DepartmentId.Equals(id), trackChanges).SingleOrDefaultAsync();
    

        public void UpdateEmployeeAsync(Department employee)
        {
            Update(employee);
        }
        public async Task<Department> GetDepartment(byte id, bool trackChanges)
        {
            var department=await FindAll(trackChanges)
                                    .Where(c=>c.DepartmentId.Equals(id))    
                                    .SingleOrDefaultAsync();
            return department;
        }
    }
}
