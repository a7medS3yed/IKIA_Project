using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Employees;
using DAL.Enums;
using DAL.Persistance.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Persistance.Data.Configurations.Employees
{
    public class EmployeeConfiguration : BaseEntityConfiguration<int, Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);

            builder.Property(E => E.FirstName).HasColumnType("varchar(50)");
            builder.Property(E => E.LastName).HasColumnType("varchar(50)");
            builder.Property(E => E.Address).HasMaxLength(100);
            builder.Property(E => E.HiringDate).HasDefaultValueSql("GETDATE()");
            builder.Property(E => E.Salary).HasPrecision(18, 2);
            builder.Property(E => E.Gender).HasConversion(EmpGen => EmpGen.ToString(),
                _EmpGen => (Gender)Enum.Parse(typeof(Gender), _EmpGen));
            builder.Property(E => E.EmployeeType).HasConversion(EmpType => EmpType.ToString(),
                _EmpType => (EmployeeType)Enum.Parse(typeof(EmployeeType), _EmpType));
        }
    }
}
