using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Common;
using DAL.Entities.Departments;
using DAL.Enums;

namespace DAL.Entities.Employees
{
    public class Employee : BaseEntity<int>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public decimal Salary { get; set; }
        public string? Address { get; set; }
        public bool IsActice { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }
        // Navigational Property
        public virtual Department? Department { get; set; }
    }
}
