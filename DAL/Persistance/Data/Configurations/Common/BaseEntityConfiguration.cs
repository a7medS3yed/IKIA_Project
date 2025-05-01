using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Persistance.Data.Configurations.Common
{
    public class BaseEntityConfiguration<TKey, TModel> : IEntityTypeConfiguration<TModel>
        where TModel : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.HasKey(B => B.Id);
            builder.Property(B => B.CreatedBy).HasMaxLength(50);
            builder.Property(B => B.LastModifiedBy).HasMaxLength(50);
            builder.Property(B => B.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(B => B.LastModifiedOn).HasComputedColumnSql("getdate()");
        }
    }

}
