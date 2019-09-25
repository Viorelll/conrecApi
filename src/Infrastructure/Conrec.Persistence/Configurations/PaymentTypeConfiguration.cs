using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class PaymentTypeConfiguration : RefTypeConfiguration, IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            base.Configure<PaymentType>(builder);
        }
    }
}
