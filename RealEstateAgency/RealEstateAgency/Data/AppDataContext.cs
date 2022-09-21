using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Configurations;
using RealEstateAgency.Models;

namespace RealEstateAgency.Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Review> Reviews { get; set; }        
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OfferConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());            
            modelBuilder.ApplyConfiguration(new RealtorConfiguration());
            modelBuilder.ApplyConfiguration(new AgencyConfiguration());
        }
    }
}
