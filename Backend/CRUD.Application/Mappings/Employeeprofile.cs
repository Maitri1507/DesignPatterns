using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Domain.Entities;


namespace CRUD.Application.Mappings
{
    public class Employeeprofile : Profile
    {
        public Employeeprofile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
