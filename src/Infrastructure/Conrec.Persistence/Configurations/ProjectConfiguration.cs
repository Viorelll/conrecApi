using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(e => e.Name);

            builder.Property(e => e.Requires);

            builder.Property(e => e.Website);

            builder.Property(e => e.FilledBy);

            builder.Property(e => e.PostedOn);

            builder.Property(e => e.StartedDate);

            builder.Property(e => e.CompletedDate);

            builder.Property(e => e.ExpectedDate);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
               .HasMany(p => p.ProjectEmployees)
               .WithOne(pe => pe.Project)
               .HasForeignKey(p => p.ProjectId);

            builder
               .HasMany(p => p.ProjectSchedules)
               .WithOne(ps => ps.Project)
               .HasForeignKey(p => p.ProjectId);

            builder
               .HasMany(p => p.ProjectEmployeePayments)
               .WithOne(ps => ps.Project)
               .HasForeignKey(p => p.ProjectId);


            #endregion
        }
    }
}
