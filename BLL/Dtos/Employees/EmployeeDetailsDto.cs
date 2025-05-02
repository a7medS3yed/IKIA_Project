using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Employees
{
    public record EmployeeDetailsDto(int Id, string FirstName, string LastName , int? Age, string? Address, decimal Salary, bool IsActive, string? Email, string? PhoneNumber, DateOnly HiringDate, string Gender, string EmployeeType, string CreatedBy, DateTime CreatedOn, string LastModifiedBy, DateTime LastModifiedOn);
}
