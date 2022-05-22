using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts;
using Employees.Contracts.Interface;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Context;
using Employees.Repository.Models;
using Employees.Repository.Models.AddEditEmployeeRepository;

namespace Employees.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AdventureWorks2019Context _repositoryContext;
        private IEmployeesRepository _employeesRepository;
        private ISearchEmployeeRepository _searchemployeeRepository;
        private IEmployeeDashboardRepository _employeedashboardRepository;
        private IEmployeeDashboard1Repository _employeedashboard1Repository;

        private IAddEditEmployeeRepository _addEditEmployeeRepository;
        private IAddEditEmployeeRepository2 _addEditEmployeeRepository2;

        private IDepartmentsRepository _departmentsRepository;


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


        public IAddEditEmployeeRepository AddEditEmployeeRepository
        {

            get
            {
                if (_addEditEmployeeRepository == null)
                {
                    _addEditEmployeeRepository = new AddEditEmployeeRepository(_repositoryContext);
                }
                return _addEditEmployeeRepository;
            }
        }
        public IAddEditEmployeeRepository2 AddEditEmployeeRepository2
        {

            get
            {
                if (_addEditEmployeeRepository2 == null)
                {
                    _addEditEmployeeRepository2 = new AddEditEmployeeRepository2(_repositoryContext);
                }
                return _addEditEmployeeRepository2;
            }
        }
        //Department
        public IDepartmentsRepository DepartmentsRepository
        {
            get
            {
                if(_departmentsRepository == null)
                {
                    _departmentsRepository = new DepartmentRepository(_repositoryContext);
                }
                return _departmentsRepository;
            }
        }

        public async Task SaveAsync()
        =>
            await _repositoryContext.SaveChangesAsync();
        
    }
}
