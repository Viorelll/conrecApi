using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectScheduleConfiguration : IEntityTypeConfiguration<ProjectSchedule>
    {
        public void Configure(EntityTypeBuilder<ProjectSchedule> builder)
        {
            builder.Property(e => e.EffectiveFrom);

            builder.Property(e => e.EffectiveTo);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            #endregion

        }
    }
}
