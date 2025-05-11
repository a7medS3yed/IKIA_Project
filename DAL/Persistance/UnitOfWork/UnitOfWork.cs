using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Contracts;
using DAL.Persistance.Data;
using DAL.Persistance.Repository;

namespace DAL.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<IDepartmentRepository> _departmentRepository;

        public UnitOfWork(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository,
            ApplicationDbContext context)
        {
            _context = context;
            _departmentRepository = new Lazy<IDepartmentRepository>(() => new DepartmentRepository(context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(context));
        }

        public IEmployeeRepository Employees => _employeeRepository.Value;

        public IDepartmentRepository Departments => _departmentRepository.Value;

        public int SaveChanges()
           => _context.SaveChanges();
        
    }
}
