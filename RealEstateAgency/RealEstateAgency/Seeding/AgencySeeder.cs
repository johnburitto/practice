using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Interfaces;
using RealEstateAgency.Models;

namespace RealEstateAgency.Seeding
{
    public class AgencySeeder : ISeeder<Agency>
    {
        private static readonly List<Agency> _agencies = new()
        {
            new Agency
            {
                id = 1,
                name = "Capitan Soap"
            }
        };

        public void Seed(EntityTypeBuilder<Agency> builder)
        {
            builder.HasData(_agencies);
        }
    }
}
