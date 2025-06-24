namespace ERP.Core.Entities
{
    public class Inventory
    {
        public int MaKho { get; set; } // Primary Key
        public string TenKho { get; set; } = null!; // Name of the inventory
        public string DiaChi { get; set; } = null!; // Address of the inventory
        public string NguoiQuanLy { get; set; } = null!; // Manager of the inventory
        public string? GhiChu { get; set; }

        // FK property
        public ICollection<StockIn> StockIns { get; set; } = new List<StockIn>();
        public ICollection<StockOut> StockOuts { get; set; } = new List<StockOut>();
        public ICollection<AvailableStock> AvailableStocks { get; set; } = new List<AvailableStock>();
    }
}
