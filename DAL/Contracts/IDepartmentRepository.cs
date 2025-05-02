using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Departments;

namespace DAL.Contracts
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll(bool tracking = false);
        Department? GetById(int id);
        int Add(Department model);
        int Update(Department model);
        int Delete(int id);
    }
}
