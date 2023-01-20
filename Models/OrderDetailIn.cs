using Linhkiendientu_aspnetmvc.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Linhkiendientu_aspnetmvc.Models
{
    public class OrderDetailIn
    {
        [Key]
        public int Id { get; set; }
        public int OrderInId { get; set; }
        public OrderIn OrderIn { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Note { get; set; }
        public IsDelete IsDelete { get; set; }
    }
}
