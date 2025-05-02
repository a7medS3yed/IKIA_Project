using System.ComponentModel.DataAnnotations;

namespace PL.Models.Department
{
    public class DepartmentDetailsViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }

        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
        public required string Description { get; set; }

        [Display(Name = "Created by")]
        public required string CreatedBy { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Last Modified by")]
        public required string LastModifiedBy { get; set; }

        [Display(Name = "Last Modified on")]
        public DateTime LastModifiedOn { get; set; }
    }
}
