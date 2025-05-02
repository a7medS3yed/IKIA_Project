using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BLL.Dtos.Employees
{
    public record CreateEmployeeDto(string FirstName, string LastName, int? Age, string? Address, decimal Salary, bool IsActive, string? Email, string? PhoneNumber, DateOnly HiringDate, Gender Gender, EmployeeType EmployeeType);
}
