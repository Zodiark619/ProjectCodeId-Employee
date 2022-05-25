using Employees.Entities.Dto;
using Employees.Entities.Models;
using AutoMapper;
using Employees.Entities.Dto.AddEditEmployeeDto;
using Employees.Entities.Dto.DepartmentOnly;
using Employees.Entities.Dto.SearchEmployee;

namespace Employees.WebApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
           // CreateMap<Employee, EmployeesDto>().ReverseMap();

            CreateMap<SearchEmployee, SearchEmployeesDto>().ReverseMap();

            //     CreateMap<AddDto, AddEditEmployee2>().ReverseMap();  //vdeparment

            //     CreateMap<AddEditEmployeeDto2, AddEditEmployee3>().ReverseMap();  //shift


            //vdeparment
            CreateMap<Person, SearchEmployeeAEDto>().ReverseMap();
            CreateMap<Employee, EmployeeOnlyAEDto>().ReverseMap();






            //department
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }

    }
}
