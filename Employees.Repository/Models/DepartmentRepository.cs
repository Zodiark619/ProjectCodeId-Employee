using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentsRepository
    {
        public DepartmentRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(Department employee)
        public void CreateDepartments(Department department)
        {
          Create(employee);
            Create(department);
        }

        public void DeleteEmployeeAsync(Department employee)
        public void DeleteDepartments(Department department)
        {
           Delete(employee);
            Delete(department);
        }

        public async Task<IEnumerable<Department>> GetAllEmployeeAsync(bool trackChanges)
        public async Task<IEnumerable<Department>> GetAllDepartments(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.DepartmentId).ToListAsync();
            return await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();
        }
            
        public async Task<Department> GetEmployeeAsync(byte id, bool trackChanges)
         =>
            await FindByCondition(c => c.DepartmentId.Equals(id), trackChanges).SingleOrDefaultAsync();
    

        public void UpdateEmployeeAsync(Department employee)
        public void UpdateDepartments(Department department)
        {
            Update(employee);
            Update(department);
        }
        public async Task<short> GetDepartmentid(string name, bool trackChanges)

        public async Task<Department> GetDepartments(short id, bool trackChanges)
        {
            var department=await FindAll(trackChanges)
                                    .Where(c=>c.Name.Equals(name))    
                                    .SingleOrDefaultAsync();
            return department.DepartmentId;
            return await FindByCondition(x => x.DepartmentId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
        
    }
}
