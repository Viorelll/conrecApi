using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class SalaryPaymentConfiguration : RefTypeConfiguration, IEntityTypeConfiguration<SalaryPayment>
    {
        public void Configure(EntityTypeBuilder<SalaryPayment> builder)
        {
            base.Configure<SalaryPayment>(builder);
        }
    }
}
