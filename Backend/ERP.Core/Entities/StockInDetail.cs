namespace ERP.Core.Entities
{
    public class StockInDetail
    {
        public int Id { get; set; }

        // FK đến StockIn (MaPhieuNhap)
        public int MaPhieuNhap { get; set; }
        public StockIn StockIn { get; set; } = null!;

        // FK đến Product (MaSP)
        public int MaSP { get; set; }
        public Product Product { get; set; } = null!;

        // Số lượng nhập - not null
        public int SoLuongNhap { get; set; }

        // Đơn giá - bigint not null
        public long DonGia { get; set; }
    }
}
