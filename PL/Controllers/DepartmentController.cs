using BLL.Service.Departments;
using Microsoft.AspNetCore.Mvc;
using PL.Models.Department;
using Route.Demo.BLL.Dtos.Departments;

namespace PL.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService, ILogger<DepartmentController> _logger) : Controller
    {
        #region Index

        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            var departmentViewModels = departments.Select(d => new DepartmentViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Code = d.Code,
                CreationDate = d.CreationDate
            }).ToList();

            return View(departmentViewModels);
        }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department == null)
                return NotFound();

            var departmentViewModel = new DepartmentDetailsViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description ?? "",
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn
            };

            return View(departmentViewModel);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
            => View();

        [HttpPost]
        public IActionResult Create(CreationDepartmentViewModel model)
        {
            var message = "Failed to Create Department";
            try
            {
                if (!ModelState.IsValid)
                    return View(model);


                var department = new CreationDepartmentDto(model.Name, model.Code, model.Description, model.CreationDate);

                var result = _departmentService.CreateDepartment(department);

                if (result > 0)
                    message = "Department Created Successfully";
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                message = "An error occurred while creating the department";
            }

            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }


        #endregion

        #region Update

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);

            if (department == null)
                return NotFound();

            var departmentViewModel = new UpdatingDepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description ?? ""
            };
            return View(departmentViewModel);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int id ,UpdatingDepartmentViewModel model)
        {
            var message = "Failed to Update Department";
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var department = new UpdatingDepartmentDto(id, model.Name, model.Code, model.Description, model.CreationDate);

                var result = _departmentService.UpdateDepartment(department);

                if (result > 0)
                    message = "Department Updated Successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                message = "An error occurred while updating the department";
            }
            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            var message = "Failed to Delete Department";
            try
            {
                var result = _departmentService.DeleteDepartment(id);
                if (result)
                    message = "Department Deleted Successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                message = "An error occurred while deleting the department";
            }
            TempData["Message"] = message;
            return RedirectToAction(nameof(Index));

        }

        #endregion
    }
}
