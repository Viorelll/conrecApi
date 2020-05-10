using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Conrec.Domain.Entities;

namespace Conrec.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.NINO).HasMaxLength(100);

            builder.Property(e => e.Experience);

            builder.Property(e => e.AvailabilWorkImmediate);

            builder.Property(e => e.AvailabilStartsOn);

            #region Keys

            builder.Property(primaryKey => primaryKey.Id);

            builder
               .HasOne(e => e.Country)
               .WithOne(c => c.Employee)
               .HasForeignKey<Employee>(u => u.CountryId);
            builder.HasIndex(x => x.CountryId).IsUnique(false);

            builder
              .HasOne(e => e.Skill)
              .WithOne(s => s.Employee)
              .HasForeignKey<Employee>(u => u.SkillId);
            builder.HasIndex(x => x.SkillId).IsUnique(false);

            builder
               .HasOne(e => e.AdditionalInformation)
               .WithOne(c => c.Employee)
               .HasForeignKey<Employee>(u => u.AdditionalInformationId);
            builder.HasIndex(x => x.AdditionalInformationId).IsUnique(false);

            builder
               .HasMany(e => e.ProjectEmployees)
               .WithOne(p => p.Employee)
               .HasForeignKey(p => p.EmployeeId);

            builder
               .HasMany(p => p.ProjectPaymentEmployees)
               .WithOne(ps => ps.Employee)
               .HasForeignKey(p => p.EmployeeId);

            #endregion
        }
    }
}
