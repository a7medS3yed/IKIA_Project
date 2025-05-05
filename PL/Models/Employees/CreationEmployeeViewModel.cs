using System.ComponentModel.DataAnnotations;

namespace PL.Models.Employees
{
    public class CreationEmployeeViewModel
    {
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public required string Gender { get; set; }
        [Display(Name = "Employee Type")]
        public required string EmployeeType { get; set; }
    }
}
