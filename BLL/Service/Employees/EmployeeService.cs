using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Employees;
using DAL.Contracts;
using DAL.Entities.Employees;

namespace BLL.Service.Employees
{
    public class EmployeeService(IEmployeeRepository _employeeRepository) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().ToList();

            //foreach (var employee in employees)
            //    yield return new EmployeeDto(employee.Id, employee.FirstName, employee.LastName, employee.Age, employee.Salary, employee.IsActice, employee.Email, employee.Gender.ToString(), employee.EmployeeType.ToString(), employee?.Department?.Name ?? "No Department");

            var employeesToReturn = employees.Select(E => new EmployeeDto(E.Id, E.FirstName, E.LastName, E.Age,
                E.Salary, E.IsActice, E.Email, E.Gender.ToString(), E.EmployeeType.ToString(), E.Department?.Name ?? "No Department")
            );
            return employeesToReturn;
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);

            if (employee == null)
                return null;

            return new EmployeeDetailsDto(employee.Id, employee.FirstName, employee.LastName, employee.Age, employee.Address, employee.Salary, employee.IsActice,
                employee.Email, employee.PhoneNumber, employee.HiringDate, employee.Gender.ToString(), employee.EmployeeType.ToString(), employee.CreatedBy, employee
                .CreatedOn, employee.LastModifiedBy, employee.LastModifiedOn, employee?.Department?.Name ?? "No Department");
        }

        public int CreateEmployee(CreateEmployeeDto employee)
        {
            var creationEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age ?? 0,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActice = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                CreatedBy = "System",
                LastModifiedBy = "System",
                DepartmentId = employee.DepartmentId
            };

            return _employeeRepository.Create(creationEmployee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
            var updatedEmployee = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age ?? 0,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActice = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                CreatedBy = "System",
                LastModifiedBy = "System",
                DepartmentId= employee.DepartmentId,
            };

            return _employeeRepository.Update(updatedEmployee);
        }
        public bool DeleteEmployee(int id)
            => _employeeRepository.Delete(id) > 0;
  
    }
}
