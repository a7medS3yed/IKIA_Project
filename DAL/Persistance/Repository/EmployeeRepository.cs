using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Entities.Employees;
using DAL.Persistance.Data;

namespace DAL.Persistance.Repository
{
    public class EmployeeRepository(ApplicationDbContext _dbContext) : GenaricRepository<Employee, int>(_dbContext), IEmployeeRepository
    {
    }
    
}
