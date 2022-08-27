using Microsoft.EntityFrameworkCore;
using RealEstateAgency.Models;

namespace RealEstateAgency.Data
{
    public class UserDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {

        }
    }
}
