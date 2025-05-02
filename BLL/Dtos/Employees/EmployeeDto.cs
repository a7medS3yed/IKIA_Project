using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Employees
{
    public record EmployeeDto(int Id, string FirstName, string LastName, int? Age, decimal Salary, bool IsActive, string? Email, string Gender, string EmployeeType);
}
