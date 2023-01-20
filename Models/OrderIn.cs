using Linhkiendientu_aspnetmvc.Models.Common;

namespace Linhkiendientu_aspnetmvc.Models
{
    public class OrderIn
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int StaffId { get; set; }
        public User User { get; set; }
        public float TotalPrice { get; set; }
        public DateTime CreateAt { get; set; }
        public string Note { get; set; }
        public IsDelete IsDelete { get; set; }
        public ICollection<OrderDetailIn> OrderDetailIns { get; set; }
    }
}
