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
        IEmployeesRepository Employee { get; }
        IAddedEmployeeRepository EmployeeAdded { get; }
        Task SaveAsync();
    }
}
