using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.Property(r => r.Name).HasMaxLength(100);

            builder.Property(r => r.PostCode).HasMaxLength(100);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            #endregion
        }
    }
}
