using Conrec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Conrec.Persistence.Configurations
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(e => e.SpecificationClarity);

            builder.Property(e => e.Communication);

            builder.Property(e => e.PaymentPromptness);

            builder.Property(e => e.Professionalism);

            builder.Property(e => e.WorkAgain);

            builder.Property(e => e.Comment).HasMaxLength(200);

            #region Keys

            builder.HasKey(primaryKey => primaryKey.Id);

            builder
                .HasOne(pr => pr.ProjectEmployee)
                .WithOne(pf => pf.ProjectFeedback)
                .HasForeignKey<Feedback>(pf => pf.ProjectEmployeeId);

            #endregion
        }
    }
}
