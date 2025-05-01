using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Demo.BLL.Dtos.Departments
{
    public record UpdatingDepartmentDto(int Id, string Name, string Code, string? Description, DateOnly CreationDate);
} 
