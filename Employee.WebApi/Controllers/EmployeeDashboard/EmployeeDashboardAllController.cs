using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employees.WebApi.Controllers.EmployeeDashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDashboardAllController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeDashboardAllController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet("EmployeeDashboardAll")]
        public async Task<string> EmployeeDashboardAll()
        {
            /*HashSet<object> dashboard = new HashSet<object>();
            var employeeSearch1 = await _repository.EmployeeDashboard1.ShowEmployeeDashboard1(trackChanges: false);
            var employeeSearch2 = await _repository.EmployeeDashboard.ShowEmployeeDashboard1(trackChanges: false);
            dashboard.Add(employeeSearch1);
            dashboard.Add(employeeSearch2);

            return JsonConvert.SerializeObject(dashboard);

*/

            Dictionary<string,object> dashboard = new Dictionary<string, object>();
            var employeeSearch1 = await _repository.EmployeeDashboard1.ShowEmployeeDashboard1(trackChanges: false);
            var employeeSearch2 = await _repository.EmployeeDashboard.ShowEmployeeDashboard1(trackChanges: false);
            dashboard.Add("Department Count",employeeSearch1);
            dashboard.Add("Employee Salary Rate",employeeSearch2);

            return JsonConvert.SerializeObject(dashboard);
            /*foreach(var i in dashboard)
            {
                JsonConvert.SerializeObject(i);
            }
            return dashboard;*/
        }   




    }
}
