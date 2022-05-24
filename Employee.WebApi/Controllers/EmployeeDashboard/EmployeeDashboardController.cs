using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Employees.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Employees.WebApi.Controllers.EmployeeDashboard
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDashboardController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeDashboardController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        /* public async Task<IActionResult> EmployeeDashboard1Rate(EmployeePayHistory employeePayHistory)
         {
             var employeeSearch = await _repository.EmployeeDashboard.ShowEmployeeDashboard1(employeePayHistory, trackChanges: false);
          */   /* { "<10",0 },
                  { "11-15",0 },
                  { "16-20",0 },
                  { "21-45",0 },
                  { ">45",0 }*/

        /*int meong = employeeSearch["<10"];
        string juju = Convert.ToString(meong);
        return JsonConvert.SerializeObject(juju);
*/
        //string json = JsonConvert.SerializeObject(employeeSearch, Formatting.Indented);

        // return Ok(JsonConvert.SerializeObject(json));
        [HttpGet("dashboard")]
        public async Task<string> EmployeeDashboard1Rate()
        {
            var employeeSearch = await _repository.EmployeeDashboard.ShowEmployeeDashboard1(trackChanges: false);

            return JsonConvert.SerializeObject(employeeSearch);

        }



    }
}
