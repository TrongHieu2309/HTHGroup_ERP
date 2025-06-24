namespace ERP.Core.Entities
{
    public class Customer
    {
        public int MaKH { get; set; }
        public string TenKhachHang { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string SoDienThoai { get; set; } = null!;
        public string? Email { get; set; }
        public string? GhiChu { get; set; }
        public int TichDiem { get; set; } = 0; // Default value for loyalty points

        public ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
    }
}
