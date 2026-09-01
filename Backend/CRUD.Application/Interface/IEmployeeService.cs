using CRUD.Application.DTOs;

namespace CRUD.Application.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO?> GetEmployeeById(int id);
        Task<bool> AddEmployee(EmployeeDTO employee);
        Task<EmployeeDTO?> UpdateEmployee(EmployeeDTO employee);
        Task<bool> DeleteEmployee(int id);
    }
}
