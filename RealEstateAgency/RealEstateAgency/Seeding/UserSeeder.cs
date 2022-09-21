using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateAgency.Interfaces;
using RealEstateAgency.Models;

namespace RealEstateAgency.Seeding
{
    public class UserSeeder : ISeeder<User>
    {
        private static readonly List<User> _users = new()
        {
            new User
            {
                id = 1,
                firstname = "Андрій",
                middlename = "Юрійович",
                lastname = "Борск",
                telephone = "+380967283875",
                email = "johnburitto@gmail.com",
                login = "owner",
                password = "owner",
                role = User.Role.Owner
            }
        };

        public void Seed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(_users);
        }
    }
}
