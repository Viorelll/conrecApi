using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public abstract class RefTypeConfiguration
    {
        public void Configure<TEntity>(EntityTypeBuilder<TEntity> builder) 
            where TEntity : RefType
        {
            builder.HasKey(primaryKey => primaryKey.Id);

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.Property(e => e.Description).HasMaxLength(250);
        }
    }
}
