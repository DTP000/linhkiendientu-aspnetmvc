using TestThuVien.Entity.Common;

namespace TestThuVien.Entity
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public IsDelete IsDeleted { get; set; }
        public ICollection<OrderIn> OrderIns { get; set; }
    }
}
