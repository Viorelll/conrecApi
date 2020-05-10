using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class ProjectPaymentEmployeeConfiguration : IEntityTypeConfiguration<ProjectPaymentEmployee>
    {
        public void Configure(EntityTypeBuilder<ProjectPaymentEmployee> builder)
        {

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            #endregion

        }
    }
}
