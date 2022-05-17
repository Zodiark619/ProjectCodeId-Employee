using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;

namespace Employees.Contracts
{
    public interface IRepositoryManager
    {
        IEmployeeDashboardRepository EmployeeDashboard { get; }
        IEmployeeDashboard1Repository EmployeeDashboard1 { get; }


        ISearchEmployeeRepository SearchEmployee { get; }

        IEmployeesRepository Employee { get; }
        Task SaveAsync();
    }
}
