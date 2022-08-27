using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgency.Models
{
    [Table("keys")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        
        public enum Role
        {
            Owner, 
            Administrator, 
            Operator,
            Guest
        }
    }
}
