using Microsoft.EntityFrameworkCore;
using TestThuVien.Entity;

namespace Linhkiendientu_API.Data
{
    public class BanHangDbContext : DbContext 
    {
        
        public BanHangDbContext(DbContextOptions<BanHangDbContext> options) : base(options)
        {
        }
        /*public DbSet<Address> Addresses { set; get; }*/
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderDetailIn> OrderDetailIns { get; set; }
        public DbSet<OrderIn> OrderIns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Primary keys

            #region Foreign key CategoryProduct

            builder.Entity<CategoryProduct>().HasKey(q =>
                new {
                    q.CategoryId,
                    q.ProductId
                });

            #endregion

            /* #region Foreign key OrderIn
             builder.Entity<OrderIn>().HasKey(q =>
                 new {
                     q.StaffId,
                     q.SupplierId
                 });
             #endregion*/

            #region Foreign key OrderDetailIn

            builder.Entity<OrderDetailIn>().HasKey(q =>
                new {
                    q.OrderInId,
                    q.ProductId
                });

            #endregion

            #region Foreign key OrderDetail

            builder.Entity<OrderDetail>().HasKey(q =>
                new {
                    q.OrderId,
                    q.ProductId
                });

            #endregion  

            // Relationships

            #region Relationships many to many Product and Order

            builder.Entity<OrderDetail>()
                .HasOne(t => t.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.OrderId);

            builder.Entity<OrderDetail>()
                .HasOne(t => t.Product)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(t => t.ProductId);

            #endregion

            #region Relationships many to many Product and OrderIn

            builder.Entity<OrderDetailIn>()
                .HasOne(t => t.OrderIn)
                .WithMany(t => t.OrderDetailIns)
                .HasForeignKey(t => t.OrderInId);

            builder.Entity<OrderDetailIn>()
                .HasOne(t => t.Product)
                .WithMany(t => t.OrderDetailIns)
                .HasForeignKey(t => t.ProductId);

            #endregion

            /*#region Relationships many to many Supplier and User
            builder.Entity<OrderIn>()
                .HasOne(t => t.User)
                .WithMany(t => t.OrderIns)
                .HasForeignKey(t => t.StaffId);
            builder.Entity<OrderIn>()
                .HasOne(t => t.Supplier)
                .WithMany(t => t.OrderIns)
                .HasForeignKey(t => t.SupplierId);
            #endregion*/

            #region Relationships many to many Category and Product

            builder.Entity<CategoryProduct>()
                .HasOne(t => t.Category)
                .WithMany(t => t.CategoryProducts)
                .HasForeignKey(t => t.CategoryId);

            builder.Entity<CategoryProduct>()
                .HasOne(t => t.Product)
                .WithMany(t => t.CategoryProducts)
                .HasForeignKey(t => t.ProductId);

            #endregion

            #region Relationships one to many User and Address

            builder.Entity<Address>().HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(au => au.UserId);

            #endregion

            #region Relationships one to many User and Order

            builder.Entity<Order>().HasOne(a => a.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(au => au.UserId);

            #endregion

            #region Relationships one to many Product and ImageProduct

            builder.Entity<ImageProduct>().HasOne(a => a.Product)
                .WithMany(u => u.ImageProducts)
                .HasForeignKey(au => au.ProductId);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}
