using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dtos.Department;
using DAL.Contracts;
using DAL.Entities.Departments;
using Route.Demo.BLL.Dtos.Departments;

namespace BLL.Service.Departments
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        public IEnumerable<DepartmentsDto> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll();

            foreach (var department in departments)
                yield return new DepartmentsDto(department.Id, department.Code, department.Name, department.CreationDate);
        }

        public DepartmentDetailsDto? GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);

            if (department is null)
                return null;

            return new DepartmentDetailsDto(department.Id, department.Name, department.Code, department.Description, department.CreationDate, department.CreatedBy, department.CreatedOn, department.LastModifiedBy, department.LastModifiedOn);
        }

        public int CreateDepartment(CreationDepartmentDto department)
        {
            var newDepartment = new Department()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = "",
                LastModifiedBy = ""
            };

            return _departmentRepository.Create(newDepartment);
        }

        public int UpdateDepartment(UpdatingDepartmentDto department)
        {
            var updatedDepartment = new Department()
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                CreationDate = department.CreationDate,
                CreatedBy = "",
                LastModifiedBy = ""
            };

            return _departmentRepository.Update(updatedDepartment);
        }

        public bool DeleteDepartment(int id)
            =>_departmentRepository.Delete(id) > 0;

    }
}
