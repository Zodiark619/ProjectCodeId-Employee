using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models.AddEditEmployeeRepository
{
    public class SearchEmployee : RepositoryBase<Person>, ISearchEmployee
    {
        public SearchEmployee(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(Person employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(Person employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<Person>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<Person> GetEmployeeAsync(int id, bool trackChanges)
        =>
            await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Person>> GetPaginationEmployeeAsync(EmployeesParameters employeesParameters, bool trackChanges)
        {
           
                var lowerCaseSearch = employeesParameters.SearchEmployees.Trim().ToLower();
                var query = FindAll(trackChanges)
                      //  .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                     //   .Take(employeesParameters.PageSize)
                        .Where(c => Convert.ToString(c.BusinessEntityId).ToLower().Contains(lowerCaseSearch)
                        || c.FirstName.ToLower().Contains(lowerCaseSearch)
                        || c.LastName.ToLower().Contains(lowerCaseSearch)
                        || c.Suffix.ToLower().Contains(lowerCaseSearch)
                        || c.PersonType.ToLower().Contains(lowerCaseSearch));
                
                    return await query.ToListAsync();

                
                
            }

        public void UpdateEmployeeAsync(Person employee)
        {
            Update(employee);
        }
    }
}
