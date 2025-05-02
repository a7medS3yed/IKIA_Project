using System.ComponentModel.DataAnnotations;

namespace PL.Models.Department
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }
    }

}
