using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Common;

namespace DAL.Entities.Departments
{
    public class Department : BaseEntity<int>
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }
    }
}
