using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 3;
        public int PageNumber { get; set; } = 3;
        private int _pageSize = 2;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
        public string OrderBy { get; set; }
    }
}
