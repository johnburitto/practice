using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Models;
using RealEstateAgency.Seeding;

namespace RealEstateAgency.Configurations
{
    public class AgencyConfiguration : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.Property(agency => agency.id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(agency => agency.name)
                .HasMaxLength(50)
                .IsRequired();

            new AgencySeeder().Seed(builder);
        }
    }
}
