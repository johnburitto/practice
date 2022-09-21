using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Models;
using RealEstateAgency.Seeding;

namespace RealEstateAgency.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(review => review.id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(review => review.review)
                .HasMaxLength(300)
                .IsRequired();

            builder.HasOne(review => review.offer)
                .WithMany(offer => offer.reviews)
                .HasForeignKey(review => review.offerid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Review_OfferId");
            
            builder.HasOne(review => review.user)
                .WithMany(user => user.reviews)
                .HasForeignKey(review => review.userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Review_UserId");

            new ReviewSeeder().Seed(builder);
        }
    }
}
