namespace ERP.Core.Entities
{
    public class StockOut
    {
        public int MaPhieuXuat { get; set; }
        // FK: MaKho → Inventory.MaKho
        public int MaKho { get; set; }

        public string NguoiXuat { get; set; } = null!;
        public DateTime NgayXuat { get; set; }
        public string? LyDoXuat { get; set; }

        // Navigation
        public Inventory Inventory { get; set; } = null!;

        // Fk property
        public ICollection<StockOutDetail> StockOutDetails { get; set; } = new List<StockOutDetail>();
    }
}
