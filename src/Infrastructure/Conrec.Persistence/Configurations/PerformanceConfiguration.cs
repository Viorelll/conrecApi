using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            builder.Property(e => e.Absences);

            builder.Property(e => e.IssuesNumber);

            builder.Property(e => e.IssuesPerDay);

            builder.Property(e => e.Warnings);

            builder.Property(e => e.WorkDays);

            builder.Property(e => e.Review).HasMaxLength(200);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            #endregion
        }
    }
}
