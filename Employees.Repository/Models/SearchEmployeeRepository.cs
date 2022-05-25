using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface.ISearchEmployee;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models
{
    public class SearchEmployeeRepository : RepositoryBase<SearchEmployee>, ISearchEmployeeRepository
    {
        public SearchEmployeeRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(SearchEmployee employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(SearchEmployee employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<SearchEmployee>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.NationalIdnumber).ToListAsync();
        }

        public async Task<SearchEmployee> GetEmployeeAsync(string id, bool trackChanges)
        =>
            await FindByCondition(c => c.NationalIdnumber.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<SearchEmployee>> GetPaginationCustomerAsync(EmployeesParameters employeesParameters, bool trackChanges, string choice, string order)
        {
            /* if (order == null)
             {*/
            if (string.IsNullOrWhiteSpace(employeesParameters.SearchEmployees))
            {
                var query = FindAll(trackChanges)
                     .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                     .Take(employeesParameters.PageSize);

              


                if (order == "Ascending")
                {
                    var queryFinish = choice.Equals("JobTitle") ? query.OrderBy(c => c.JobTitle) :
                                     choice.Equals("FirstName") ? query.OrderBy(c => c.FirstName) :
                                     choice.Equals("LastName") ? query.OrderBy(c => c.LastName) :
                                     choice.Equals("NationalIdNumber") ? query.OrderBy(c => c.NationalIdnumber) :
                                     query.OrderBy(c => c.BusinessEntityId);
                    return await queryFinish.ToListAsync();

                }
                else
                {
                    var queryFinish = choice.Equals("JobTitle") ? query.OrderByDescending(c => c.JobTitle) :
                                 choice.Equals("FirstName") ? query.OrderByDescending(c => c.FirstName) :
                                 choice.Equals("LastName") ? query.OrderByDescending(c => c.LastName) :
                                 choice.Equals("NationalIdNumber") ? query.OrderByDescending(c => c.NationalIdnumber) :
                                 query.OrderByDescending(c => c.BusinessEntityId);
                    return await queryFinish.ToListAsync();
                }
            }
            else
            {
                var lowerCaseSearch = employeesParameters.SearchEmployees.Trim().ToLower();
                var query = FindAll(trackChanges)
                        .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                        .Take(employeesParameters.PageSize)
                        .Where(c => c.JobTitle.ToLower().Contains(lowerCaseSearch)
                        || c.FirstName.ToLower().Contains(lowerCaseSearch)
                        || c.LastName.ToLower().Contains(lowerCaseSearch)
                        || c.Name.ToLower().Contains(lowerCaseSearch)
                        || c.NationalIdnumber.ToLower().Contains(lowerCaseSearch));
                if (order == "Ascending") { 
                var queryFinish = choice.Equals("JobTitle") ? query.OrderBy(c => c.JobTitle) :
                                 choice.Equals("FirstName") ? query.OrderBy(c => c.FirstName) :
                                 choice.Equals("LastName") ? query.OrderBy(c => c.LastName) :
                                 choice.Equals("NationalIdNumber") ? query.OrderBy(c => c.NationalIdnumber) :
                                 query.OrderBy(c => c.BusinessEntityId);
                    return await queryFinish.ToListAsync();

                }
                else
                {
                    var queryFinish = choice.Equals("JobTitle") ? query.OrderByDescending(c => c.JobTitle) :
                                 choice.Equals("FirstName") ? query.OrderByDescending(c => c.FirstName) :
                                 choice.Equals("LastName") ? query.OrderByDescending(c => c.LastName) :
                                 choice.Equals("NationalIdNumber") ? query.OrderByDescending(c => c.NationalIdnumber) :
                                 query.OrderByDescending(c => c.BusinessEntityId);
                    return await queryFinish.ToListAsync();
                }
                //return await queryFinish.ToListAsync();
            }
        }  








       

        public void UpdateEmployeeAsync(SearchEmployee employee)
        {
            Update(employee);
        }

    }
}
