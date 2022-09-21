using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Models;
using RealEstateAgency.Seeding;

namespace RealEstateAgency.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(user => user.firstname)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(user => user.middlename)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(user => user.lastname)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(user => user.telephone)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(user => user.email)
                .HasMaxLength(50)
                .IsRequired();
            
            builder.Property(user => user.login)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(user => user.password)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(user => user.role)
                .IsRequired();

            new UserSeeder().Seed(builder);
        }
    }
}
