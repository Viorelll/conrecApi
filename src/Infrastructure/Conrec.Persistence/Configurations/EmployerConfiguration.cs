using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Conrec.Domain.Entities;

namespace Conrec.Persistence.Configurations
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {

           #region Keys

            builder.Property(primaryKey => primaryKey.Id);

            builder
                .HasOne(e => e.JobRole)
                .WithOne(jr => jr.Employer)
                .HasForeignKey<Employer>(u => u.JobRoleId);
            builder.HasIndex(x => x.JobRoleId).IsUnique(false);

            #endregion
        }
    }
}
