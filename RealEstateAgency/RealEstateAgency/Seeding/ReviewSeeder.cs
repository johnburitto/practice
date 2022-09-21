using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Interfaces;
using RealEstateAgency.Models;

namespace RealEstateAgency.Seeding
{
    public class ReviewSeeder : ISeeder<Review>
    {
        private static readonly List<Review> _reviews = new()
        {
            new Review
            {
                id = 1,
                review = "Повний дрейн",
                offerid = 1,
                userid = 1
            }
        };

        public void Seed(EntityTypeBuilder<Review> builder)
        {
            builder.HasData(_reviews);
        }
    }
}
