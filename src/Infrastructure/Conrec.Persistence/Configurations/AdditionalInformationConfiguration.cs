using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Conrec.Domain.Entities;

namespace Conrec.Persistence.Configurations
{
    public class AdditionalInformationConfiguration : IEntityTypeConfiguration<AdditionalInformation>
    {
        public void Configure(EntityTypeBuilder<AdditionalInformation> builder)
        {
            builder.Property(r => r.WillingMiles);

            builder.Property(r => r.Details).HasMaxLength(100);

            builder.Property(r => r.HasOwnCar);

            builder.Property(r => r.HasRequiredPPE);

            #region Keys

        builder.HasKey(primaryKey => primaryKey.Id);

            #endregion
        }
    }
}
