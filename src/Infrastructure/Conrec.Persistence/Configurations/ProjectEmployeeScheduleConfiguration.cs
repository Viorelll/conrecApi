using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectEmployeeScheduleConfiguration : IEntityTypeConfiguration<ProjectEmployeeSchedule>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployeeSchedule> builder)
        {
            builder.Property(e => e.EffectiveFrom);

            builder.Property(e => e.EffectiveTo);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            #endregion

        }
    }
}
