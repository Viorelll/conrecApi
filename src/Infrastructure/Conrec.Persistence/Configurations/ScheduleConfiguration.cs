using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.Property(e => e.IsBreakPaid);

            builder.Property(e => e.TotalHoursWorked);

            builder.Property(e => e.BreakStart);

            builder.Property(e => e.BreakEnd);

            builder.Property(e => e.DayStart);

            builder.Property(e => e.DayEnd);


            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder.HasIndex(x => x.WorkDayId).IsUnique(false);

            builder
              .HasMany(p => p.ProjectSchedules)
              .WithOne(ps => ps.Schedule)
              .HasForeignKey(p => p.ScheduleId);

            #endregion
        }
    }
}
