using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos.Department
{
    public record DepartmentsDto(int Id, string Code, string Name, DateOnly CreationDate);
}
