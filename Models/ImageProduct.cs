using Linhkiendientu_aspnetmvc.Models.Common;

namespace Linhkiendientu_aspnetmvc.Models
{
    public class ImageProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Url { get; set; }
        public IsDelete IsDelete { get; set; }
    }
}
