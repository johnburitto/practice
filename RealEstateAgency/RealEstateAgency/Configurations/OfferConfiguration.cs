using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Models;
using RealEstateAgency.Seedings;

namespace RealEstateAgency.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.Property(offer => offer.id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(offer => offer.title)
                .HasMaxLength(150)
                .IsRequired();
            
            builder.Property(offer => offer.description)
                .HasMaxLength(300)
                .IsRequired();
            
            builder.Property(offer => offer.price)
                .IsRequired();
            
            builder.Property(offer => offer.square)
                .IsRequired();
            
            builder.Property(offer => offer.offertype)
                .IsRequired();
            
            builder.Property(offer => offer.buytype)
                .IsRequired();

            builder.HasOne(offer => offer.user)
                .WithMany(user => user.offers)
                .HasForeignKey(offer => offer.userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Offers_UserId");

            new OfferSeeder().Seed(builder);
        }
    }
}
