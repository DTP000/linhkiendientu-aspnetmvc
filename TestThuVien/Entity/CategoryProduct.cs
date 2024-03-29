﻿using TestThuVien.Entity.Common;

namespace TestThuVien.Entity
{
    public class CategoryProduct
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public IsDelete IsDeleted { get; set; }
    }
}
