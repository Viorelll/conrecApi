using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
                .HasMany(t => t.Members)
                .WithOne(m => m.Team)
                .HasForeignKey(fr => fr.TeamId);

            builder.HasIndex(x => x.SalaryPaymentId).IsUnique(false);

            #endregion
        }
    }
}
