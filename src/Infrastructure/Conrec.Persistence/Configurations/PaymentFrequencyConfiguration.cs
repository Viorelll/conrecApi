using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class PaymentFrequencyConfiguration : RefTypeConfiguration, IEntityTypeConfiguration<PaymentFrequency>
    {
        public void Configure(EntityTypeBuilder<PaymentFrequency> builder)
        {
            base.Configure<PaymentFrequency>(builder);
        }
    }
}
