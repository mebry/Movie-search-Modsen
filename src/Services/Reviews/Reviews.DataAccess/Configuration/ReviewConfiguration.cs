using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviews.DataAccess.Entities;

namespace Reviews.DataAccess.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .HasOne(x => x.TypeOfReview)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.TypeOfReviewId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Description)
                .HasMaxLength(5000)
                .IsRequired();
        }
    }
}
