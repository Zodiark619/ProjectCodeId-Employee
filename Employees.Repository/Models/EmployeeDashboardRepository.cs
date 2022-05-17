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
    public class EmployeeDashboardRepository : RepositoryBase<EmployeePayHistory>, IEmployeeDashboardRepository
    {
        public EmployeeDashboardRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(EmployeePayHistory employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(EmployeePayHistory employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<EmployeePayHistory>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<EmployeePayHistory> GetEmployeeAsync(string id, bool trackChanges)
        =>
            await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();
        

        public void UpdateEmployeeAsync(EmployeePayHistory employee)
        {
            Update(employee);
        }














        public async Task<Dictionary<string, int>> ShowEmployeeDashboard1(bool trackChanges)
        {
            /*
             * var query = FindAll(trackChanges)
                         .Skip((employeesParameters.PageNumber - 1) * employeesParameters.PageSize)
                         .Take(employeesParameters.PageSize)
                         .Where(c => c.JobTitle.ToLower().Contains(lowerCaseSearch)
                         || c.FirstName.ToLower().Contains(lowerCaseSearch)
                         || c.LastName.ToLower().Contains(lowerCaseSearch)
                         || c.Name.ToLower().Contains(lowerCaseSearch)
                         || c.NationalIdnumber.ToLower().Contains(lowerCaseSearch));
                 var queryFinish = choice.Equals("JobTitle") ? query.OrderByDescending(c => c.JobTitle) :
                                  choice.Equals("FirstName") ? query.OrderByDescending(c => c.FirstName) :
                                  choice.Equals("LastName") ? query.OrderByDescending(c => c.LastName) :
                                  choice.Equals("NationalIdNumber") ? query.OrderByDescending(c => c.NationalIdnumber) :
                                  query.OrderByDescending(c => c.BusinessEntityId);
             return await queryFinish.ToListAsync();*/
            Dictionary<string, int> dictRateSalary = new Dictionary<string, int>
            {
                //{"6-10",0 },
                {"<10",0 },
                {"11-15",0 },
                {"16-20",0 },
                {"21-45",0 },
                {">45",0 }
            };
            var counter = 0;
            var query = await FindAll(trackChanges)
                .OrderBy(c => c.BusinessEntityId)
                .OrderByDescending(c => c.ModifiedDate).ToListAsync();
            foreach(var item in query)
            {
                if (counter !=item.BusinessEntityId)
                {
                    //      if (item.Rate>= 6 && item.Rate < 11){
                          if (item.Rate < 11){

                    dictRateSalary["<10"]++;
                        counter = item.BusinessEntityId;

                    }
                    else if(item.Rate >= 11 && item.Rate < 16)
                    {
                        dictRateSalary["11-15"]++;
                        counter = item.BusinessEntityId;

                    }
                    else if (item.Rate >= 16 && item.Rate < 21)
                    {
                        dictRateSalary["16-20"]++;
                        counter = item.BusinessEntityId;

                    }
                    else if (item.Rate >= 21 && item.Rate <= 46)
                    {
                        dictRateSalary["21-45"]++;
                        counter = item.BusinessEntityId;

                    }
                    else
                    {
                        dictRateSalary[">45"]++;
                        counter = item.BusinessEntityId;

                    }
                }
                else
                {
                    counter = item.BusinessEntityId;
                    continue;
                }
            }
            return dictRateSalary;
            



        }
    }
}
