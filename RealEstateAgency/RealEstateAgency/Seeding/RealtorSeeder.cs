using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Interfaces;
using RealEstateAgency.Models;

namespace RealEstateAgency.Seeding
{
    public class RealtorSeeder : ISeeder<Realtor>
    {
        private static readonly List<Realtor> _realtors = new()
        {
            new Realtor
            {
                id = 1,
                firstname = "Петро",
                middlename = "Петрович",
                lastname = "Петренко",
                experience = 5, 
                agencyid = 1
            }
        };

        public void Seed(EntityTypeBuilder<Realtor> builder)
        {
            builder.HasData(_realtors);
        }
    }
}
