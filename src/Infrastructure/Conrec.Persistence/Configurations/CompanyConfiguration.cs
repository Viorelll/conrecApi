using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(100);

            builder.Property(e => e.Reference);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
               .HasMany(c => c.Projects)
               .WithOne(p => p.Company)
               .HasForeignKey(c => c.CompanyId);

            #endregion
        }
    }
}
