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
        private readonly AdventureWorks2019Context _context;

        public AddEditEmployeeRepository(AdventureWorks2019Context context):base(context)
        {
            _context = context;
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
        // =>
        {
            //var query = await repositoryContext.AddEditEmployee2s.Include(c=>c.Departments).Where(q=>q.BusinessEntityId==id).ToListAsync();
                       return await FindAll(trackChanges)
                      //  .Contains(d=>d.Departments)
                            .Where(c => c.BusinessEntityId.Equals(id))
                               .OrderBy(c => c.BusinessEntityId)
                               .ThenByDescending(x => x.ModifiedDate)
                              // .Contains(c=>c.Departments)
                               .FirstOrDefaultAsync();


        }

        //await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();





        public void UpdateEmployeeAsync(AddEditEmployee2 employee)
        {
            Update(employee);

        }



        public async Task<AddEditEmployee2> GetIncludeEmployeeAsync(int id, bool trackChanges)
        {
           /* var query = await FindAll(trackChanges)
               .OrderBy(c => c.BusinessEntityId)
               .ThenByDescending(x => x.ModifiedDate)
               .ThenByDescending(x=>x.)
               .ToListAsync();*/
            /*var result = await _context.Set<AddEditEmployee2>()
                .Where(c => c.BusinessEntityId.Equals(id))
                
                .OrderBy(c => c.BusinessEntityId)
                 .ThenByDescending(x => x.ModifiedDate)
                 .Include(q => q.Departments)
                 
                .FirstOrDefaultAsync(q=>q.BusinessEntityId==id);
                
            return result;*/
            /*var country = await result.Include(q => q.Hotels)
                
                .ToListAsync(q => q.Id == id);*/

            return await FindAll(trackChanges)
                            //  .Contains(d=>d.Departments)
                            .Where(c => c.BusinessEntityId.Equals(id))
                               .OrderBy(c => c.BusinessEntityId)
                               .ThenByDescending(x => x.ModifiedDate)
                               .FirstOrDefaultAsync();
        }

    }
}
