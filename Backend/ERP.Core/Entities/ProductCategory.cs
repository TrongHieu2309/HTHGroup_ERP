namespace ERP.Core.Entities
{
    public class ProductCategory
    {
        public int MaMatHang { get; set; } // primary key int
        public string TenMatHang { get; set; } = null!; // nvarchar 100 not null
        public int SoLuong { get; set; } // int not null
        public long TongChiPhi { get; set; } // bigint not null

        // FK của bảng Product
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
