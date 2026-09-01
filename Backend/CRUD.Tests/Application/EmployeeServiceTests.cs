using AutoMapper;
using CRUD.Application.DTOs;
using CRUD.Application.Services;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces;
using Moq;


namespace CRUD.Tests.Application
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeService _service;

        public EmployeeServiceTests()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
            });


            _mapper = config.CreateMapper();
            _service = new EmployeeService(_employeeRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetAllEmployees_ReturnList()
        {
            var employees = new List<Employee>
            {
                new Employee {Id = 1, Name = "Employee 1", Email = "Employee1@gmail.com", Salary = 75000},
                new Employee {Id = 2, Name = "Employee 2", Email = "Employee2@gmail.com", Salary =80000}
            };

            _employeeRepository.Setup(r => r.GetAllEmployeesAsync()).ReturnsAsync(employees);

            var result = await _service.GetAllEmployeesAsync();

            var list = result.ToList();
            Assert.Equal(1, list[0].Id);
        }


        [Fact]
        public async Task GetEmployeeById_ReturnsEmployeeDto()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 1,
                Name = "John Doe",
                Email = "test@gmail.com",
                Salary = 50000

            };

            _employeeRepository.Setup(repo => repo.GetEmployeeById(1)).ReturnsAsync(employee);

            //Act
            var result = await _service.GetEmployeeById(1);

            //Asset
            Assert.NotNull(result);
            Assert.Equal(employee.Id, result.Id);
            Assert.Equal(employee.Name, result.Name);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnNull()
        {
            // Arrange
            _employeeRepository.Setup(repo => repo.GetEmployeeById(1)).ReturnsAsync((Employee?)null);

            var result = await _service.GetEmployeeById(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task AddEmployee_returntrue()
        {
            var dto = new EmployeeDTO
            {
                Name = "Test",
                Email = "test@gmail.com",
                Salary = 50000
            };
            

            _employeeRepository.Setup(r=>r.AddEmployee(It.IsAny<Employee>())).ReturnsAsync(true);
            var result = await _service.AddEmployee(dto);
            Assert.True(result);
        }

        [Fact]
        public async Task UpdateEmployee_returnsDTO()
        {
            var dto = new EmployeeDTO
            {
                Id = 1,
                Name = "Test",
                Email = "test@gmail.com"
            };
            var updated = new Employee
            {
                Id = 1,
                Name = "UpdatedTest",
                Email = "updated@test.com"
            };

            _employeeRepository.Setup(r => r.UpdateEmployee(It.IsAny<Employee>())).ReturnsAsync(updated);

            var result = await _service.UpdateEmployee(dto);
            Console.WriteLine(result.Name);

            Assert.Equal(1, result.Id);
            Assert.Equal("UpdatedTest", result.Name);
        }

        [Fact]
        public async Task UpdateEmployee_returnsnull()
        {
            var dto = new EmployeeDTO
            {
                Id = 1,
                Name = "Test",
                Email = "test@gmail.com"
            };
            
            _employeeRepository.Setup(r => r.UpdateEmployee(It.IsAny<Employee>())).ReturnsAsync((Employee?)null);

            var result = await _service.UpdateEmployee(dto);

            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteEmployee_Returnstrue()
        {
            _employeeRepository.Setup(r=>r.DeleteEmployee(1)).ReturnsAsync(true);
            var result = await _service.DeleteEmployee(1);
            Assert.True(result);

        }

        //[Fact]
        //public async Task DeleteEmployee_ReturnsFalse_WhenNotFound()
        //{
        //    _employeeRepository
        //        .Setup(r => r.DeleteEmployee(99))
        //        .ReturnsAsync(false);

        //    var result = await _service.DeleteEmployee(99);

        //    Assert.False(result);
        //}
    }
}
