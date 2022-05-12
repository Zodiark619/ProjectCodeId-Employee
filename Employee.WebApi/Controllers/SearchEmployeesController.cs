using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Employees.Entities.Dto;
using Employees.Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchEmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SearchEmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetEmployeeSearch([FromQuery] EmployeesParameters employeesParameters, string choice)
        {
            var employeeSearch = await _repository.SearchEmployee.GetPaginationCustomerAsync(employeesParameters, trackChanges: false,choice);
            var employeeDto = _mapper.Map<IEnumerable<SearchEmployeesDto>>(employeeSearch);
            return Ok(employeeDto);
        }
    }
}
