using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;

namespace Employees.Contracts
{
    public interface IRepositoryManager
    {
      
        IAddEditEmployeeRepository AddEditEmployeeRepository { get; }
        IAddEditEmployeeRepository2 AddEditEmployeeRepository2 { get; }



        IEmployeeDashboardRepository EmployeeDashboard { get; }
        IEmployeeDashboard1Repository EmployeeDashboard1 { get; }


        ISearchEmployeeRepository SearchEmployee { get; }

        IEmployeesRepository Employee { get; }
        Task SaveAsync();
    }
}
