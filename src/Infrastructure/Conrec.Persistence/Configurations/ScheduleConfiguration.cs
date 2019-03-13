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

            builder.Property(e => e.BreakTime);

            builder.Property(e => e.StartTime);

            builder.Property(e => e.EndTime);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);
            builder.HasIndex(x => x.WorkDayId).IsUnique(false);

            #endregion
        }
    }
}
