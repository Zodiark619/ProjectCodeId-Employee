using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Employees.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.WebApi.Controllers
{
    [Route("api/employees/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        /*[HttpGet]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var employee = await _repository.Employee.GetAllEmployeeAsync(trackChanges: false);
            var employeeDto = _mapper.Map<IEnumerable<EmployeesDto>>(employee);

            return Ok(employeeDto);
        }*/
    }
}
