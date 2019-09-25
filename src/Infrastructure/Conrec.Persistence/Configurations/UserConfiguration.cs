using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Conrec.Domain.Entities;

namespace Conrec.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName).HasMaxLength(100);

            builder.Property(e => e.LastName).HasMaxLength(100);

            builder.Property(e => e.Password).HasMaxLength(512);

            builder.Property(e => e.Email).HasMaxLength(100);

            builder.Property(e => e.RegisterDate);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
              .HasOne(u => u.Employee)
              .WithOne(u => u.User)
              .HasForeignKey<Employee>(u => u.Id)
              .IsRequired();

            builder
              .HasOne(ur => ur.Employer)
              .WithOne(u => u.User)
              .HasForeignKey<Employer>(u => u.Id)
              .IsRequired();

            builder
               .HasOne(ur => ur.UserRole)
               .WithOne(u => u.User)
               .HasForeignKey<User>(u => u.UserRolesId);
            builder.HasIndex(x => x.UserRolesId).IsUnique(false);

            builder
               .HasOne(r => r.Region)
               .WithOne(c => c.User)
               .HasForeignKey<User>(u => u.RegionId);
            builder.HasIndex(x => x.RegionId).IsUnique(false);

            builder
               .HasMany(u => u.Contacts)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

            builder
               .HasMany(u => u.Banks)
               .WithOne(b => b.User)
               .HasForeignKey(b => b.UserId);

            builder
               .HasMany(u => u.Notifications)
               .WithOne(n => n.User)
               .HasForeignKey(n => n.UserId);

            #endregion
        }
    }
}
