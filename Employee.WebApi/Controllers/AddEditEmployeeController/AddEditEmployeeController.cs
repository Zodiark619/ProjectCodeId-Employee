using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Employees.Contracts;
using Employees.Contracts.Interface.IAddEditEmployeeRepository;
using Employees.Entities.Dto.AddEditEmployeeDto;
using Employees.Entities.Models;
using Employees.Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employees.WebApi.Controllers.AddEditEmployeeController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEditEmployeeController : ControllerBase
    {
        private readonly IAddEditEmployeeRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AddEditEmployeeController(IAddEditEmployeeRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


       [HttpPost("addEmployee")]
        public async Task<IActionResult> PostCustomer([FromBody] GetPersonDto3 dto)
        {
            /*var customerEntity = _mapper.Map<Employee>(dto);
            _repository.AddEmployee.CreateEmployeeAsync(customerEntity);
            await _repository.SaveAsync();

            var customerResult = _mapper.Map<AddDto>(customerEntity);
            return CreatedAtRoute("AddById", new { id = customerEntity.BusinessEntityId }, customerResult);
          */
            //------------------------------------------
            
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            var employee = new Employee
            {
                LoginId=dto.LoginId,
                SalariedFlag=dto.SalariedFlag,
                CurrentFlag=dto.CurrentFlag,
                Rowguid=dto.Rowguid,
               BusinessEntityId=dto.BusinessEntityId,
                NationalIdnumber = dto.NationalIdnumber,
                BirthDate =dto.BirthDate,
                MaritalStatus = dto.MaritalStatus,
                Gender = dto.Gender,
                HireDate = dto.HireDate,
                VacationHours = dto.VacationHours,
                SickLeaveHours = dto.SickLeaveHours,
                JobTitle = dto.JobTitle,
                ModifiedDate = DateTime.Now,
            };
            _repository.AddEmployee.CreateEmployeeAsync(employee);
           
            await _repository.SaveAsync();
            var departmentId = _repository.DepartmentRepository.GetDepartmentid(dto.Department,false);
            var shiftId = _repository.ShiftRepository.GetShiftid(dto.Shift, false);
            
            

            var employeeDepartmentHistory = new EmployeeDepartmentHistory
            {

                BusinessEntityId = dto.BusinessEntityId,

                DepartmentId = await departmentId,
                ShiftId=await shiftId,
                StartDate=date,
                ModifiedDate=DateTime.Now  

            };
            _repository.EmployeeDepartmentHistoryRepository.CreateEmployeeAsync(employeeDepartmentHistory);
            await _repository.SaveAsync();
            var employeePayHistory = new EmployeePayHistory
            {

                BusinessEntityId = dto.BusinessEntityId,

                RateChangeDate = DateTime.Now,
                Rate=dto.Rate,
                PayFrequency=Convert.ToByte(dto.PayFrequency),
                ModifiedDate=DateTime.Now
            };
            _repository.EmployeePayHistoryRepository.CreateEmployeeAsync(employeePayHistory);


            await _repository.SaveAsync();


             return CreatedAtRoute("CustomerById", new { id = employee.BusinessEntityId }, employee);
            
        }

        //unique rowguid,nationalidnumber,businessentityid



















        [HttpGet("{id}", Name = "CustomerById")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var person = await _repository.SearchEmployee.GetEmployeeAsync(id, false); //person
            var employee = await _repository.AddEmployee.GetEmployeeAsync(id, false); //employee
            var pay = await _repository.EmployeePayHistoryRepository.GetEmployeeAsync(id, false); //payhistory
            
            var departmentHistory = await _repository.EmployeeDepartmentHistoryRepository.GetEmployeeAsync(id, false); //department

            var shift_id = Convert.ToByte(departmentHistory.ShiftId);
            var shift = await _repository.ShiftRepository.GetEmployeeAsync(shift_id, false); //shift
            var department_id = Convert.ToByte(departmentHistory.DepartmentId);
            var department = await _repository.DepartmentRepository.GetEmployeeAsync(department_id, false); //shift



            if (person == null)
            {
                return NotFound();
            }
            

            var employeeDto = new GetPersonDto2
                {
                    FullName = person.FirstName + " " + person.LastName,
                    Suffix = person.Suffix,

                    NationalIdnumber = employee.NationalIdnumber,
                    BirthDate = employee.BirthDate,
                    MaritalStatus = employee.MaritalStatus,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate,
                    VacationHours = employee.VacationHours,
                    SickLeaveHours = employee.SickLeaveHours,
                    
                    Rate = pay.Rate,
                    ModifiedDate = employee.ModifiedDate,
                    PayFrequency = pay.PayFrequency,

                    Department=department.Name,
                    JobTitle = employee.JobTitle,
                    Shift = shift.Name,
                    StartTime = shift.StartTime,
                    EndTime = shift.EndTime



                };
                return Ok(employeeDto);
            
                
            
        }

        [HttpGet("searchEmployee")]
        public async Task<IActionResult> GetEmployeeSearch([FromQuery] EmployeesParameters employeesParameters)
        {
            var employeeSearch = await _repository.SearchEmployee.GetPaginationEmployeeAsync(employeesParameters, trackChanges: false);
            var employeeDto = _mapper.Map<IEnumerable<SearchEmployeeDto>>(employeeSearch);
            return Ok(employeeDto);
        }



















        /* var employeeDto = new GetPersonDto
                {
                    FullName = person.FirstName + " " + person.LastName,
                    Suffix = person.Suffix,
                    NationalIdnumber = employee.NationalIdnumber,
                    BirthDate = employee.BirthDate,
                    MaritalStatus = employee.MaritalStatus,
                    Gender = employee.Gender,
                    HireDate = employee.HireDate,
                   // Rate = employee.Rate,
                    ModifiedDate = employee.ModifiedDate,
                    //PayFrequency = employee.PayFrequency,
                    VacationHours = employee.VacationHours,
                    SickLeaveHours = employee.SickLeaveHours,
                   // Department = person.Suffix,

                };*/


        /*[HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] AddDto addDto)
        {
            
            //object modelState digunakan untuk validasi data yang ditangkap oleh customerdto
           *//* if (!ModelState.IsValid)
            {
               // _logger.LogError("Invalid modelstate customerdto");
                return UnprocessableEntity(ModelState);
            }*//*

            var customerEntity = _mapper.Map<AddEditEmployee2>(addDto);
            //customerEntity.ModifiedDate = DateTime.Now;
            _repository.AddEditEmployeeRepository.CreateEmployeeAsync(customerEntity);

            //var fullname = customerEntity.FirstName + " " + customerEntity.MiddleName + " " + customerEntity.LastName;

            //string[] textSplit = customerEntity.FullName.Split(" ");
            
            
            await _repository.SaveAsync();

            var customerResult = _mapper.Map<AddDto>(customerEntity);
            //return CreatedAtRoute("AddById", new { id = customerEntity.BusinessEntityId }, customerResult);
            return Ok();

        }




        //[HttpGet]
        //[HttpGet("{id}", Name = "CustomerById")]
        [HttpGet("{id}", Name = "AddById")]
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
                var employeeDto = _mapper.Map<AddDto>(employee);
                return Ok(employeeDto);
                
            }
        }*/

    }
}
