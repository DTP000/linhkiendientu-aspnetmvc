using TestThuVien.Entity.Common;

namespace TestThuVien.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public UserStatus UserStatus { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<OrderIn> OrderIns { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
