namespace ERP.Core.Entities
{
    public class StockOutDetail
    {
        public int Id { get; set; }

        public int MaPhieuXuat { get; set; } // FK → StockOut
        public int MaSP { get; set; }        // FK → Product

        public int SoLuongXuat { get; set; }
        public string? GhiChu { get; set; }

        // Navigation properties
        public StockOut StockOut { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
