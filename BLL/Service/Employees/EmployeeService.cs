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
            var employees = _employeeRepository.GetAll();

            foreach (var employee in employees)
                yield return new EmployeeDto(employee.Id, employee.FirstName, employee.LaststName, employee.Age, employee.Salary, employee.IsActice, employee.Email, employee.Gender.ToString(), employee.EmployeeType.ToString());
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);

            if (employee == null)
                return null;

            return new EmployeeDetailsDto(employee.Id, employee.FirstName, employee.LaststName, employee.Age, employee.Address, employee.Salary, employee.IsActice,
                employee.Email, employee.PhoneNumber, employee.HiringDate, employee.Gender.ToString(), employee.EmployeeType.ToString(), employee.CreatedBy, employee
                .CreatedOn, employee.LastModifiedBy, employee.LastModifiedOn);
        }

        public int CreateEmployee(CreateEmployeeDto employee)
        {
            var creationEmployee = new Employee()
            {
                FirstName = employee.FirstName,
                LaststName = employee.LastName,
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
                LastModifiedBy = "System"
            };

            return _employeeRepository.Create(creationEmployee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employee)
        {
            var updatedEmployee = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LaststName = employee.LastName,
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
                LastModifiedBy = "System"
            };

            return _employeeRepository.Update(updatedEmployee);
        }
        public bool DeleteEmployee(int id)
            => _employeeRepository.Delete(id) > 0;
  
    }
}
