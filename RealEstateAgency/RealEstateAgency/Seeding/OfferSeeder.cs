using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Interfaces;
using RealEstateAgency.Models;

namespace RealEstateAgency.Seedings
{
    public class OfferSeeder : ISeeder<Offer>
    {
        private static readonly List<Offer> _offers = new()
        {
            new Offer
            {
                id = 1,
                title = "Квартира 416(3)",
                description = "Дрейн, що сказати",
                price = 3500,
                square = 3,
                offertype = Offer.OfferType.Room,
                buytype = Offer.BuyType.Rent,
                userid = 1
            }
        };

        public void Seed(EntityTypeBuilder<Offer> builder)
        {
            builder.HasData(_offers);
        }
    }
}
