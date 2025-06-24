namespace ERP.Core.Entities
{
    public class ProviderEntity
    {
        public int Id { get; set; }
        public string MaNCC { get; set; } = null!;
        public string TenNCC { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string MoTa { get; set; } = null!;
        public string SoDienThoai { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NguoiTiepNhan { get; set; } = null!;

        // Navigation FK property (kiểu như các bảng khác đang có FK tham chiếu đến bảng này)
        public ICollection<StockIn> StockIns { get; set; } = new List<StockIn>();
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
