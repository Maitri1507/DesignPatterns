using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeById(int id);
        Task<bool> AddEmployee(Employee employee);
        Task<Employee?> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int id);

    }
}
