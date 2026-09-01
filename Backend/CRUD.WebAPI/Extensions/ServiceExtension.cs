using CRUD.Application.Interface;
using CRUD.Application.Mappings;
using CRUD.Application.Services;
using CRUD.Domain.Interfaces;
using CRUD.Infrastructure.Repositories;

namespace CRUD.WebAPI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
        public static void AddInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
        public static void AddApplicationMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Employeeprofile));
        }
    }
}