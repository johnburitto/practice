using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Models;
using RealEstateAgency.Seeding;

namespace RealEstateAgency.Configurations
{
    public class RealtorConfiguration : IEntityTypeConfiguration<Realtor>
    {
        public void Configure(EntityTypeBuilder<Realtor> builder)
        {
            builder.Property(realtor => realtor.id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(realtor => realtor.firstname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(realtor => realtor.middlename)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(realtor => realtor.lastname)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(realtor => realtor.experience)
               .IsRequired();

            builder.HasOne(realtor => realtor.agency)
                .WithMany(agency => agency.realtors)
                .HasForeignKey(realtor => realtor.agencyid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Realtor_AgencyId");

            new RealtorSeeder().Seed(builder);
        }
    }
}
