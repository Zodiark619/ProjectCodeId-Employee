using Employees.Entities.Dto;
using Employees.Entities.Models;
using AutoMapper;
namespace Employees.WebApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeesDto>().ReverseMap();

            CreateMap<SearchEmployee, SearchEmployeesDto>().ReverseMap();

        }

    }
}
