using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Employees.Entities.Dto.AddEditEmployeeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.WebApi.Controllers.AddEditEmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEditEmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AddEditEmployeeController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        //[HttpGet]
        //[HttpGet("{id}", Name = "CustomerById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            
            var employee = await _repository.AddEditEmployeeRepository.GetEmployeeAsync(id, false);
            if (employee == null)
            {
                _logger.LogInfo($"Customer with id :{id} not found");
                return NotFound();
            }
            else
            {
                var employeeDto = _mapper.Map<AddEditEmployeeDto>(employee);
                return Ok(employeeDto);
                
            }
        }

    }
}
