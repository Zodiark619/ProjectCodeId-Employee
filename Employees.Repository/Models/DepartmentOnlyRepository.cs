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
    public class DepartmentOnlyRepository : RepositoryBase<Department>, IDepartmentOnlyRepository
    {
        public DepartmentOnlyRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDepartments(Department department)
        {
            Create(department);
        }

        public void DeleteDepartments(Department department)
        {
            Delete(department);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }


        public void UpdateDepartments(Department department)
        {
            Update(department);
        }

        public async Task<Department> GetDepartments(short id, bool trackChanges)
        {
            return await FindByCondition(x => x.DepartmentId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
