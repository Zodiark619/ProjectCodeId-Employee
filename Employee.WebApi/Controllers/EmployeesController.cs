using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Employees.Entities.Models;
using Employees.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Employees.Entities.RequestFeatures;

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
        [HttpGet]
        public async Task<IActionResult> GetEmployeeSearchAsync([FromQuery] EmployeesParameters employeesParameters)
        {
            var employee = await _repository.EmployeeAdded.GetPaginationVAddedEmployeeAsync(employeesParameters, trackChanges: false);
            var employeeDto = _mapper.Map<IEnumerable<CreateEmployeeDto>>(employee);

            return Ok(employeeDto);
        }
        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployeeAsync([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            if (createEmployeeDto == null)
            {
                _logger.LogError("Employee is null");
                return BadRequest("Employee is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInfo("Invalid model state createEmployeeDto");
                return UnprocessableEntity(ModelState);
            }

            var employeeEntity = _mapper.Map<VAddedEmployee>(createEmployeeDto);
            _repository.EmployeeAdded.CreateVAddedEmployeeAsync(employeeEntity);

            await _repository.SaveAsync();
            var employeeResult = _mapper.Map<CreateEmployeeDto>(employeeEntity);
            return Ok(employeeResult);
        }

        [HttpDelete("{BusinessEntityId}")]
        public async Task<IActionResult> DeleteVAddedEmployeeAsync(string NationalNumberID)
        {
            var employee = await _repository.EmployeeAdded.GetVAddedEmployeeAsync(NationalNumberID, trackChanges:false);
            if(employee == null)
            {
                _logger.LogInfo($"Customer with busnines entity id : {NationalNumberID} doesn't exist");
                return NotFound();
            }

            _repository.EmployeeAdded.DeleteVAddedEmployeeAsync(employee);
            await _repository.SaveAsync();
            return NoContent();
        }


    }
}
