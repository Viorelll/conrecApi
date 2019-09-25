using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectPaymentConfiguration : IEntityTypeConfiguration<ProjectPayment>
    {
        public void Configure(EntityTypeBuilder<ProjectPayment> builder)
        {

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
              .HasOne(pp => pp.Payment)
              .WithOne(p => p.ProjectPayment)
              .HasForeignKey<ProjectPayment>(p => p.PaymentId);

            #endregion

        }
    }
}
