using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts;
using Employees.Contracts.Interface;
using Employees.Entities.Context;
using Employees.Repository.Models;

namespace Employees.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AdventureWorks2019Context _repositoryContext;
        private IEmployeesRepository _employeesRepository;
        private ISearchEmployeeRepository _searchemployeeRepository;


        public RepositoryManager(AdventureWorks2019Context repositoryContext)
        {
            _repositoryContext = repositoryContext;
            
        }

        public IEmployeesRepository Employee
        {
            
            get
            {
                if (_employeesRepository == null)
                {
                    _employeesRepository = new EmployeesRepository(_repositoryContext);
                }
                return _employeesRepository;
            }
        }
        public ISearchEmployeeRepository SearchEmployee
        {

            get
            {
                if (_searchemployeeRepository == null)
                {
                    _searchemployeeRepository = new SearchEmployeeRepository(_repositoryContext);
                }
                return _searchemployeeRepository;
            }
        }

        public async Task SaveAsync()
        =>
            await _repositoryContext.SaveChangesAsync();
        
    }
}
