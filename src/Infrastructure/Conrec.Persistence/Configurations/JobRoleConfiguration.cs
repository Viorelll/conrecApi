using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class JobRoleConfiguration : RefTypeConfiguration, IEntityTypeConfiguration<JobRole>
    {
        public void Configure(EntityTypeBuilder<JobRole> builder)
        {
            base.Configure<JobRole>(builder);
        }
    }
}
