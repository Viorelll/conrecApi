﻿using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(e => e.AccountNumber).HasMaxLength(100);

            builder.Property(e => e.ShortCode).HasMaxLength(100);

            builder.Property(e => e.Subject).HasMaxLength(100);

            builder.Property(e => e.Amount);

            builder.Property(e => e.OriginalPayRate);

            builder.Property(e => e.CoefficientPayRate);

            builder.Property(e => e.AdjustedPayRate);

            builder.Property(e => e.WorkedHours);

            builder.Property(e => e.PaymentDate);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder.HasIndex(x => x.CurrencyId).IsUnique(false);

            builder.HasIndex(x => x.PaymentFrequencyId).IsUnique(false);

            builder.HasIndex(x => x.PaymentTypeId).IsUnique(false);


            #endregion
        }
    }
}
