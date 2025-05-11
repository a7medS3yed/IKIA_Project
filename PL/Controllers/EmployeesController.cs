using AutoMapper;
using BLL.Dtos.Employees;
using BLL.Service.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PL.Models.Employees;

namespace PL.Controllers
{
    public class EmployeesController(IEmployeeService _employeeService, IMapper _mapper, ILogger<EmployeesController> _logger) : Controller
    {
        #region Inedex

        [HttpGet] //Employees/Index
        public IActionResult Index(string? searchEmployeeName)
        {
            var employees = _employeeService.GetAllEmployees(searchEmployeeName).ToList();

            var mappingEmployee = _mapper.Map<IEnumerable<EmployeeDto>, IEnumerable<EmployeesViewModel>>(employees);

            return View(mappingEmployee);
        }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);

            if (employee == null)
                return NotFound();

            var mappingEmployee = _mapper.Map<EmployeeDetailsDto, EmployeeDetailsViewModel>(employee);

            return View(mappingEmployee);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
           => View();

        [HttpPost]
        public IActionResult Create(CreationEmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var employee = _mapper.Map<CreationEmployeeViewModel, CreateEmployeeDto>(model);

                var result = _employeeService.CreateEmployee(employee) > 0;
                if (!result)   
                    ModelState.AddModelError("", "Failed to create employee");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                ModelState.AddModelError("", "An error occurred while creating the employee");

            }

            return RedirectToAction("Index");
        }


        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();
            var mappingEmployee = _mapper.Map<EmployeeDetailsDto, UpdationEmployeeViewModel>(employee);
            return View(mappingEmployee);
        }

        [HttpPost]
        public IActionResult Edit(UpdationEmployeeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var employee = _mapper.Map<UpdationEmployeeViewModel, UpdatedEmployeeDto>(model);
                var result = _employeeService.UpdateEmployee(employee) > 0;

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError("", "Failed to update employee");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace!.ToString());
                ModelState.AddModelError("", "An error occurred while updating the employee");
            }

            return View(model); // Stay on the same page with validation errors
        }


        #endregion

        #region Delete

        public IActionResult Delete(int id)
        {
            
            var employee = _employeeService.DeleteEmployee(id);

            return RedirectToAction("Index");
        }

        #endregion
    }
}
