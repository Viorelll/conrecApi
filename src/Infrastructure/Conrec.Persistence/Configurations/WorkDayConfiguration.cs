using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class WorkDayConfiguration : RefTypeConfiguration, IEntityTypeConfiguration<WorkDay>
    {
        public void Configure(EntityTypeBuilder<WorkDay> builder)
        {
            base.Configure<WorkDay>(builder);
        }
    }
}
