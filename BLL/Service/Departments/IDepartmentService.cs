using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Department;
using Route.Demo.BLL.Dtos.Departments;

namespace BLL.Service.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentsDto> GetAllDepartments();
        DepartmentDetailsDto? GetDepartmentById(int id);
        int CreateDepartment(CreationDepartmentDto department);
        int UpdateDepartment(UpdatingDepartmentDto department);
        bool DeleteDepartment(int id);
    }
}
