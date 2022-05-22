﻿using AutoMapper;
using Employees.Contracts;
using Employees.Contracts.Interface;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Dto;
using Employees.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DepartmentController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name="DepartmentId")]
        public async Task<IActionResult> GetDepartmentById (short id)
        {
            var department = await _repository.DepartmentsRepository.GetDepartments(id, trackChanges: false);
            if(department == null)
            {
                _logger.LogInfo($"Category with {id} Not Found");
                return NotFound();
            }
            else
            {
                var departmentDto = _mapper.Map<DepartmentDto>(department);
                return Ok(departmentDto);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var department = await _repository.DepartmentsRepository.GetAllDepartments(trackChanges: false);
                var departmentDto = _mapper.Map<IEnumerable<DepartmentDto>>(department);
                return Ok(departmentDto);
            }
            catch(Exception ex)
            {
                _logger.LogError($"{nameof(GetAllDepartment)}message, {ex}");
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            if(departmentDto == null)
            {
                _logger.LogError("Department is null");
                return BadRequest("Departmenet is null");
            }

            var department = _mapper.Map<Department>(departmentDto);
            _repository.DepartmentsRepository.CreateDepartments(department);
            await _repository.SaveAsync();

            var result = _mapper.Map<DepartmentDto>(department);
            return NoContent();
           // return CreatedAtRoute("DepartmentID", new { id = result.DepartmentId }, result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(short id)
        {
            var department = await _repository.DepartmentsRepository.GetDepartments(id, trackChanges : false);
            if(department == null)
            {
                _logger.LogInfo($"Department with {id} doesnt exist");
                return NotFound();
            }
            _repository.DepartmentsRepository.DeleteDepartments(department);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatedDepartment(short id, [FromBody] DepartmentDto departmentDto)
        {
            if(departmentDto == null)
            {
                _logger.LogError("Department must not be null");
                return BadRequest("Department must not be null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("invalid model state for departmentDto");
                return UnprocessableEntity(ModelState);
            }
            var department = await _repository.DepartmentsRepository.GetDepartments(id,trackChanges: false);
            if(department == null)
            {
                _logger.LogError($"Department with {id} not found");
                return NotFound();
            }

            _mapper.Map(departmentDto, department);
            _repository.DepartmentsRepository.UpdateDepartments(department);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}