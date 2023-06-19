using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reviews.DataAccess.Entities;
using Reviews.DataAccess.SeedData;

namespace Reviews.DataAccess.Configuration
{
    public class TypeOfReviewConfiguration : IEntityTypeConfiguration<TypeOfReview>
    {
        public void Configure(EntityTypeBuilder<TypeOfReview> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasData(
                SeedReviews.PositiveTypeOfReview,
                SeedReviews.NegativeTypeOfReview,
                SeedReviews.NeutralTypeOfReview);
        }
    }
}
