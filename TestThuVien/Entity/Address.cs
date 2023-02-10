using TestThuVien.Entity.Common;

namespace TestThuVien.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string _Address { get; set; }
        public bool IsDefault { get; set; }
        public IsDelete IsDelete { get; set; }
    }
}
