using System.ComponentModel.DataAnnotations;

namespace PL.Models.Department
{
    public class CreateEditBaseDepartment
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
