using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Common;
using DAL.Entities.Departments;
using DAL.Persistance.Data.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Persistance.Data.Configurations.Departments
{
    public class DepartmentConfiguration : BaseEntityConfiguration<int, Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);

            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            builder.Property(D => D.Name).HasMaxLength(50);
            builder.Property(D => D.Code).HasMaxLength(10);
            builder.Property(D => D.Description).HasMaxLength(100);
            builder.Property(D => D.CreationDate).HasDefaultValueSql("GETDATE()");
        }
    }
    
}
