using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Context;

namespace Employees.Repository.Models.AddEditEmployeeRepository
{
    public class AddEditEmployeeRepositoryManager : IAddEditEmployeeRepositoryManager
    {
        private readonly AdventureWorks2019Context _repositoryContext;
        private IAddEmployee _addEmployee;
        private ISearchEmployee _searchEmployee;
        private IEmployeePayHistoryRepository _employeePayHistory;

        private IEmployeeDepartmentHistoryRepository _employeeDepartmentHistory;
        private IShiftRepository _shift;

        private IDepartmentRepository _departmentRepository;
        public AddEditEmployeeRepositoryManager(AdventureWorks2019Context repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IDepartmentRepository DepartmentRepository
        {

            get
            {
                if (_departmentRepository == null)
                {
                    _departmentRepository = new DepartmentRepository(_repositoryContext);
                }
                return _departmentRepository;
            }
        }
        public IEmployeeDepartmentHistoryRepository EmployeeDepartmentHistoryRepository
        {
            get
            {
                if (_employeeDepartmentHistory == null)
                {
                    _employeeDepartmentHistory = new EmployeeDepartmentHistoryRepository(_repositoryContext);
                }
                return _employeeDepartmentHistory;
            }
        }
        public IShiftRepository ShiftRepository
        {
            get
            {
                if (_shift == null)
                {
                    _shift = new ShiftRepository(_repositoryContext);
                }
                return _shift;
            }
        }













        public IEmployeePayHistoryRepository EmployeePayHistoryRepository
        {
            get
            {
                if (_employeePayHistory == null)
                {
                    _employeePayHistory = new EmployeePayHistoryRepository(_repositoryContext);
                }
                return _employeePayHistory;
            }
        }

        public ISearchEmployee SearchEmployee
        {
            get
            {
                if (_searchEmployee == null)
                {
                    _searchEmployee = new SearchEmployee(_repositoryContext);
                }
                return _searchEmployee;
            }
        }

        public IAddEmployee AddEmployee
        {
            get
            {
                if (_addEmployee == null)
                {
                    _addEmployee = new AddEmployee(_repositoryContext);
                }
                return _addEmployee;
            }
        }

        
        public async Task SaveAsync()
        =>
            await _repositoryContext.SaveChangesAsync();
    }
}
