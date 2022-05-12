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

        public async Task<IEnumerable<SearchEmployee>> GetPaginationCustomerAsync(EmployeesParameters employeesParameters, bool trackChanges, string choice/*,string order*/)
        {
            if (string.IsNullOrWhiteSpace(employeesParameters.SearchEmployees))
            {
                return await FindAll(trackChanges).OrderBy(c => c.NationalIdnumber)
                    .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                    .ToListAsync();
            }
            else
            {
                var lowerCaseSearch = employeesParameters.SearchEmployees.Trim().ToLower();

                /*     return await FindAll(trackChanges)
                     .Where(c => c.FirstName.ToLower().Contains(lowerCaseSearch))
                     //.Include(c => c.Orders)
                     .OrderBy(c => c.FirstName)
                     .ToListAsync();*/
                /* if (order == "ascending")
                 {*/
                if (choice != null) { 
                    switch (choice)
                    {
                        case "jobTitle":
                            return await FindAll(trackChanges)
                         .Where(c => c.JobTitle.ToLower().Contains(lowerCaseSearch))
                         //.Include(c => c.Orders)
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .OrderBy(c => c.JobTitle)
                         .ToListAsync();

                        case "birthDate":
                            return await FindAll(trackChanges)
                         .Where(c => c.BirthDate.Equals(lowerCaseSearch))
                         //.OrderBy(c => c.BirthDate.())
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .ToListAsync();

                        case "hireDate":
                            return await FindAll(trackChanges)
                         .Where(c => c.HireDate.Equals(lowerCaseSearch))
                       //  .OrderBy(c => c.FirstName)
                       .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .ToListAsync();

                        case "Department":
                            return await FindAll(trackChanges)
                         .Where(c => c.Name.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.Name)
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .ToListAsync();

                        case "firstName":
                            return await FindAll(trackChanges)
                         .Where(c => c.FirstName.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .ToListAsync();

                        case "lastName":
                            return await FindAll(trackChanges)
                         .Where(c => c.LastName.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.LastName)
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .ToListAsync();

                        case "nationalId":
                            return await FindAll(trackChanges)
                         .Where(c => c.NationalIdnumber.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.NationalIdnumber)
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                         .ToListAsync();
                    default:
                        return await FindAll(trackChanges)
                     .Where(c => c.NationalIdnumber.ToLower().Contains(lowerCaseSearch))
                     .OrderBy(c => c.FirstName)
                     .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                     .ToListAsync();
                }
                }
                else
                {
                    return await FindAll(trackChanges)
                                         .Where(c => c.NationalIdnumber.ToLower().Contains(lowerCaseSearch))
                                         .OrderBy(c => c.FirstName)
                                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                    .Take(employeesParameters.PageSize)
                                         .ToListAsync();
                }




                /*}*/
                /* else
                {
                    switch (choice)
                    {
                        case "jobTitle":
                            return await FindAll(trackChanges)
                         .Where(c => c.JobTitle.ToLower().Contains(lowerCaseSearch))
                         //.Include(c => c.Orders)
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                        case "birthDate":
                            return await FindAll(trackChanges)
                         .Where(c => c.BirthDate.Equals(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                        case "hireDate":
                            return await FindAll(trackChanges)
                         .Where(c => c.HireDate.Equals(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                        case "Department":
                            return await FindAll(trackChanges)
                         .Where(c => c.Name.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                        case "firstName":
                            return await FindAll(trackChanges)
                         .Where(c => c.FirstName.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                        case "lastName":
                            return await FindAll(trackChanges)
                         .Where(c => c.LastName.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                        case "nationalId":
                            return await FindAll(trackChanges)
                         .Where(c => c.NationalIdnumber.ToLower().Contains(lowerCaseSearch))
                         .OrderBy(c => c.FirstName)
                         .ToListAsync();

                    }
                }*/









            }
        }
        public void UpdateEmployeeAsync(SearchEmployee employee)
        {
            Update(employee);
        }

    }
}
