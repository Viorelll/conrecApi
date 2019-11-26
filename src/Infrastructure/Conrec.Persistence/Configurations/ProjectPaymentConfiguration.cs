using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectPaymentConfiguration : IEntityTypeConfiguration<ProjectEmployeePayment>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployeePayment> builder)
        {

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
              .HasOne(pp => pp.Payment)
              .WithOne(p => p.ProjectEmployeePayment)
              .HasForeignKey<ProjectEmployeePayment>(p => p.PaymentId);

            #endregion

        }
    }
}
