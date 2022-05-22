using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models.AddEditEmployeeRepository
{
    public class AddEditEmployeeRepository2: RepositoryBase<AddEditEmployee3>, IAddEditEmployeeRepository2
    {
        public AddEditEmployeeRepository2(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(AddEditEmployee3 employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(AddEditEmployee3 employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<AddEditEmployee3>> GetAllEmployeeAsync(bool trackChanges)
        {

              return await FindAll(trackChanges).OrderBy(c => c.DepartmentId).ToListAsync();
          
        }

        public async Task<IEnumerable<AddEditEmployee3>> GetEmployeeAsync(int id, bool trackChanges)
        =>
            //await FindByCondition(c => c.BusinessEntityId.Equals(id) , trackChanges).SingleOrDefaultAsync();
              await FindAll(trackChanges)
                  .Where(c => c.DepartmentId.Equals(id))
                     .OrderBy(c => c.DepartmentId)
                     .ThenByDescending(x => x.ModifiedDate)
                     .ToListAsync();


        public void UpdateEmployeeAsync(AddEditEmployee3 employee)
        {
            Update(employee);

        }
    }
}
