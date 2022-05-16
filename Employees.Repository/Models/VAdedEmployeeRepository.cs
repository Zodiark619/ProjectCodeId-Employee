using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Entities.Dto;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;

namespace Employees.Repository.Models
{
    public class VAdedEmployeeRepository : RepositoryBase<VAddedEmployee>, IAddedEmployeeRepository
    {
        public VAdedEmployeeRepository(AdventureWorks2019Context repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateVAddedEmployeeAsync(VAddedEmployee vAddedEmployee)
        {
            Create(vAddedEmployee);
        }

        public void DeleteVAddedEmployeeAsync(VAddedEmployee vAddedEmployee)
        {
            Delete(vAddedEmployee);
        }

        public async Task<IEnumerable<VAddedEmployee>> GetAllVAddedEmployeeAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.NationalIdnumber).ToListAsync();
        }

        public async Task<IEnumerable<VAddedEmployee>> GetPaginationVAddedEmployeeAsync(EmployeesParameters employeesParameters, bool trackChanges)
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
                    .OrderBy(c => c.FirstName)
                    .ToListAsync();
            }
        }

        public async Task<VAddedEmployee> GetVAddedEmployeeAsync(string id, bool trackChanges)
        =>
            await FindByCondition(c => c.NationalIdnumber.Equals(id), trackChanges).SingleAsync();


        public void UpdateVAddedEmployeeAsync(VAddedEmployee vAddedEmployee)
        {
            Update(vAddedEmployee);
        }
    }
}
