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
    public class EmployeeDashboard1Repository : RepositoryBase<VEmployeeDepartment>, IEmployeeDashboard1Repository
    {
        public EmployeeDashboard1Repository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateEmployeeAsync(VEmployeeDepartment employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(VEmployeeDepartment employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<VEmployeeDepartment>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<VEmployeeDepartment> GetEmployeeAsync(string id, bool trackChanges)
        =>
            await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<Dictionary<string, int>> ShowEmployeeDashboard1(bool trackChanges)
        {
           /* Dictionary<string, int> dictRateSalary = new Dictionary<string, int>
            {

                {"Engineering",0 },
                {"Tool Design",0 },
                {"Sales",0 },
                {"Marketing",0 },
                {"Purchasing",0 },
                {"Research and Development",0 },
                {"Production",0 },
                {"Production Control",0 },
                {"Human Resources",0 },
                {"Finance",0 },
                {"Information Services",0 },
                {"Document Control",0 },
                {"Quality Assurance",0 },
                {"Facilities and Maintenance",0 },
                {"Shipping and Receiving",0 },
                {"Executive",0 },
                {"Total",0 }
            };*/

            var counter = 0;
            var query = await FindAll(trackChanges)
                .OrderBy(c => c.BusinessEntityId)
                .ToListAsync();
            List<string> meong = new List<string>();
            foreach(var item in query)
            {
               
                meong.Add(item.Department);
            }
            meong.Add("Total");
            var meong1=meong.Distinct().ToList();
            
            Dictionary<string, int> dictRateSalary = new Dictionary<string, int>();
            foreach (var item in meong1)
            {
             
                dictRateSalary.Add(item,0);
            }
            foreach (var item in query)
            {
                if (counter != item.BusinessEntityId)
                {
                    //      if (item.Rate>= 6 && item.Rate < 11){
                    if (item.Department =="Engineering")
                    {
                        dictRateSalary["Engineering"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Tool Design")
                    {
                        dictRateSalary["Tool Design"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Sales")
                    {
                        dictRateSalary["Sales"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Marketing")
                    {
                        dictRateSalary["Marketing"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Purchasing")
                    {
                        dictRateSalary["Purchasing"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Research and Development")
                    {
                        dictRateSalary["Research and Development"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Production")
                    {
                        dictRateSalary["Production"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Production Control")
                    {
                        dictRateSalary["Production Control"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Human Resources")
                    {
                        dictRateSalary["Human Resources"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Finance")
                    {
                        dictRateSalary["Finance"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Information Services")
                    {
                        dictRateSalary["Information Services"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Document Control")
                    {
                        dictRateSalary["Document Control"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Quality Assurance")
                    {
                        dictRateSalary["Quality Assurance"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Facilities and Maintenance")
                    {
                        dictRateSalary["Facilities and Maintenance"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Shipping and Receiving")
                    {
                        dictRateSalary["Shipping and Receiving"]++;
                        counter = item.BusinessEntityId;
                    }
                    else if (item.Department == "Executive")
                    {
                        dictRateSalary["Executive"]++;
                        counter = item.BusinessEntityId;
                    }
                    dictRateSalary["Total"]++;
                }
                

                /*else
                {
                    counter = item.BusinessEntityId;
                    continue;
                }*/
            }
            return dictRateSalary;
        }

        public void UpdateEmployeeAsync(VEmployeeDepartment employee)
        {
            Update(employee);
        }
    }
}
