using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Entities.Departments;
using DAL.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Persistance.Repository
{
    public class DepartmentRepository(ApplicationDbContext _dbContext) : IDepartmentRepository
    {
        public IEnumerable<Department> GetAll(bool tracking = false)
        {
            if (!tracking)
               return _dbContext.Departments.AsNoTracking();

            // if tracking is true, return the departments with tracking
            return _dbContext.Departments;
        }

        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department == null)
                return null;

            // if department is not null, return the department
            return department;
        }

        public int Add(Department model)
        {
            var department = _dbContext.Departments.Add(model);
            return _dbContext.SaveChanges();
        }

        public int Update(Department model)
        {
            var department = _dbContext.Departments.Update(model);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);

            if (department == null)
                return 0;

            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

    }
}
