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
    public class AddEmployee : RepositoryBase<Employee>, IAddEmployee
    {
        public AddEmployee(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
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
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId).ToListAsync();

        }

        public async Task<Employee> GetEmployeeAsync(int id, bool trackChanges)
        =>
            await FindByCondition(c => c.BusinessEntityId.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateEmployeeAsync(Employee employee)
        {
            Update(employee);
        }
    }
}
