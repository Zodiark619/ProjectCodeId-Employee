using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Context;

namespace Employees.Repository.Models.AddEditEmployeeRepository
{
    public class AddEditEmployeeRepositoryManager : IAddEditEmployeeRepositoryManager
    {
        private readonly AdventureWorks2019Context _repositoryContext;
        private IAddEmployee _addEmployee;
        private ISearchEmployee _searchEmployee;

        public AddEditEmployeeRepositoryManager(AdventureWorks2019Context repositoryContext)
        {
            _repositoryContext = repositoryContext;
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
