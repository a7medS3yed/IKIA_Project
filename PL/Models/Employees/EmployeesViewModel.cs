using System.ComponentModel.DataAnnotations;

namespace PL.Models.Employees
{
    public class EmployeesViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Employee Type")]    
        public required string EmployeeType { get; set; }
        public int? Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public required string Gender { get; set; }

        //[Display(Name ="Departments")]
        //public int? DepartmentId { get; set; }

        public string? Department { get; set; }
    }
}
