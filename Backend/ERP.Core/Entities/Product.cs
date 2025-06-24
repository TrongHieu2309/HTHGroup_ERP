namespace ERP.Core.Entities
{
    public class Product
    {
        // MaSP int not null primary key
        public int MaSP { get; set; }
        public string TenSanPham { get; set; } = null!; // nvarchar 100 not null
        public string? MoTa { get; set; } // nvarchar 255 nullable

        // FK: MaNCC → ProviderEntity
        public int MaNCC { get; set; }
        public ProviderEntity Provider { get; set; } = null!;

        // FK: MaMatHang → ProductCategory
        public int MaMatHang { get; set; }
        public ProductCategory ProductCategory { get; set; } = null!;

        public long DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime NgayNhap { get; set; }
        public string TrangThai { get; set; } = null!; // nvarchar 10 not null 

        // FK property
        public ICollection<StockInDetail> StockInDetails { get; set; } = new List<StockInDetail>();
        public ICollection<StockOutDetail> StockOutDetails { get; set; } = new List<StockOutDetail>();
        public ICollection<AvailableStock> AvailableStocks { get; set; } = new List<AvailableStock>();
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; } = new List<ReceiptDetail>();
    }
}
