using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Repository.Models
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentsRepository
    {
        public DepartmentRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
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
