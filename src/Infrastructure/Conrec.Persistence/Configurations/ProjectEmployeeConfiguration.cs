﻿using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
        {
            builder.Property(e => e.TotalTimeWork);

            builder.Property(e => e.IsActive);

            builder.Property(e => e.HasCustomSchedule);

            builder.Property(e => e.IsHoursConfirmed);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
               .HasMany(pe => pe.ProjectReports)
               .WithOne(r => r.ProjectEmployee)
               .HasForeignKey(r => r.ProjectEmployeeId);

            builder
               .HasMany(pe => pe.ProjectEmployeeSchedules)
               .WithOne(ps => ps.ProjectEmployee)
               .HasForeignKey(ps => ps.ProjectEmployeeId);

            #endregion

        }
    }
}
