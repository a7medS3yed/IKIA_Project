using System.ComponentModel.DataAnnotations;

namespace PL.Models.Employees
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }

        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public int? Age { get; set; }
        public required string Gender { get; set; }
        [Display(Name = "Employee Type")]
        public required string EmployeeType { get; set; }
        [Display(Name = "Created By")]
        public required string CreatedBy { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Last Modified By")]
        public required string LastModifiedBy { get; set; }
        [Display(Name = "Last Modified On")]
        public DateTime LastModifiedOn { get; set; }

        //public int? DepartmentId { get; set; }
        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }
    }
}
