using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class TermsAndConditionsConfiguration : IEntityTypeConfiguration<TermsAndConditions>
    {
        public void Configure(EntityTypeBuilder<TermsAndConditions> builder)
        {
            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            #endregion
        }
    }
}
