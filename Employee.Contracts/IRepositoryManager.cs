using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Contracts.Interface;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Contracts.Interface.IDepartmentOnly;
using Employees.Contracts.Interface.IEmployeeDashboard;
using Employees.Contracts.Interface.ISearchEmployee;

namespace Employees.Contracts
{
    public interface IRepositoryManager
    {

        IDepartmentOnlyRepository DepartmentOnlyRepository { get; }




        IAddEditEmployeeRepository AddEditEmployeeRepository { get; }
        IAddEditEmployeeRepository2 AddEditEmployeeRepository2 { get; }



        IEmployeeDashboardRepository EmployeeDashboard { get; }
        IEmployeeDashboard1Repository EmployeeDashboard1 { get; }


        ISearchEmployeeRepository SearchEmployee { get; }

        IEmployeesRepository Employee { get; }
        Task SaveAsync();
    }
}
