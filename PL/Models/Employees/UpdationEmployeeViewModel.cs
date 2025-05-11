using System.ComponentModel.DataAnnotations;

namespace PL.Models.Employees
{
    public class UpdationEmployeeViewModel : CreateEditBaseEmployee
    {
        public int Id { get; set; }

    }
}
