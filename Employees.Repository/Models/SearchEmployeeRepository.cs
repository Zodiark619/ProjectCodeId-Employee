using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models
{
    public class SearchEmployeeRepository : RepositoryBase<SearchEmployee>,ISearchEmployeeRepository
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

        public async Task<IEnumerable<SearchEmployee>> GetPaginationCustomerAsync(EmployeesParameters employeesParameters, bool trackChanges)
        {
            if (string.IsNullOrWhiteSpace(employeesParameters.SearchEmployees))
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            else
            {
                var lowerCaseSearch = employeesParameters.SearchEmployees.Trim().ToLower();
                return await FindAll(trackChanges)
                    .Where(c => c.FirstName.ToLower().Contains(lowerCaseSearch))
                    //.Include(c => c.Orders)
                    .OrderBy(c => c.FirstName)
                    .ToListAsync();
            }
        }
        public void UpdateEmployeeAsync(SearchEmployee employee)
        {
            Update(employee);
        }

    }
}
