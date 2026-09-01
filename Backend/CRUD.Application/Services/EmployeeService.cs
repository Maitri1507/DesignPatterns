using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Application.Interface;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;


namespace CRUD.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddEmployee(EmployeeDTO employee)
        {
            await _employeeRepository.AddEmployee(_mapper.Map<Employee>(employee));
            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return true;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = _mapper.Map<List<EmployeeDTO>>(await _employeeRepository.GetAllEmployeesAsync());
            return employees;
        }

        public async Task<EmployeeDTO?> GetEmployeeById(int id)
        {
          var employee = _mapper.Map<EmployeeDTO?>(await _employeeRepository.GetEmployeeById(id));
          return employee;
        }

        public async Task<EmployeeDTO?> UpdateEmployee(EmployeeDTO employee)
        {
            var existing = await _employeeRepository.UpdateEmployee(_mapper.Map<Employee>(employee));
            return _mapper.Map<EmployeeDTO?>(existing);
        }
    }
}
