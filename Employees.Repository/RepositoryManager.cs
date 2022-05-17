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
        private IEmployeeDashboardRepository _employeedashboardRepository;
        private IEmployeeDashboard1Repository _employeedashboard1Repository;



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
        public IEmployeeDashboardRepository EmployeeDashboard
        {

            get
            {
                if (_employeedashboardRepository == null)
                {
                    _employeedashboardRepository = new EmployeeDashboardRepository(_repositoryContext);
                }
                return _employeedashboardRepository;
            }
        }


        public IEmployeeDashboard1Repository EmployeeDashboard1
        {

            get
            {
                if (_employeedashboard1Repository == null)
                {
                    _employeedashboard1Repository = new EmployeeDashboard1Repository(_repositoryContext);
                }
                return _employeedashboard1Repository;
            }
        }


        public async Task SaveAsync()
        =>
            await _repositoryContext.SaveChangesAsync();
        
    }
}
