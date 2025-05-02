using System.ComponentModel.DataAnnotations;

namespace PL.Models.Department
{
    public class UpdatingDepartmentViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }

        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
