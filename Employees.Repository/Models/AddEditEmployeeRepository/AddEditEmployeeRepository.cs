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
    public class AddEditEmployeeRepository : RepositoryBase<AddEditEmployee2>, IAddEditEmployeeRepository
    {
        public AddEditEmployeeRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(AddEditEmployee2 employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(AddEditEmployee2 employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<AddEditEmployee2>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<AddEditEmployee2> GetEmployeeAsync(int id, bool trackChanges)
        =>
             await FindAll(trackChanges)
                .Where(c=>c.BusinessEntityId.Equals(id))
                   .OrderBy(c => c.BusinessEntityId)
                   .ThenByDescending(x => x.ModifiedDate)
                   .FirstOrDefaultAsync();
            //await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();
            

        


        public void UpdateEmployeeAsync(AddEditEmployee2 employee)
        {
            Update(employee);

        }
    }
}
