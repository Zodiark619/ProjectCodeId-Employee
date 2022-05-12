using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts;
using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Entities.Dto;
using Employees.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models
{
    public class EmployeesRepository : RepositoryBase<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(AdventureWorks2019Context repositoryContext):base(repositoryContext)
        {

        }

        public void CreateEmployeeAsync(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployeeAsync(Employee employee)
        {
            Delete(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.NationalIdnumber).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(string id, bool trackChanges)
        =>
            await FindByCondition(c => c.NationalIdnumber.Equals(id), trackChanges).SingleOrDefaultAsync();
        

        public void UpdateEmployeeAsync(Employee employee)
        {
            Update(employee);
        }






        //Task<IEnumerable<EmployeesSearchDto>> SearchEmployees(CategoryParameters categoryParameters, bool trackChanges);

    }
}
