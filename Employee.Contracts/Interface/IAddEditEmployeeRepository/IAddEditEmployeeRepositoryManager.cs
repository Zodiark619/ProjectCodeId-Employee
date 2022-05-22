using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Contracts.Interface.IAddEditEmployeeRepository
{
    public interface IAddEditEmployeeRepositoryManager
    {
            IAddEmployee AddEmployee { get; }
        ISearchEmployee SearchEmployee { get; }
            Task SaveAsync();
    }
}
