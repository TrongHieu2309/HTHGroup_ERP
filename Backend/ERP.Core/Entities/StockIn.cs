namespace ERP.Core.Entities
{
    public class StockIn
    {
        // Mã phiếu nhập - primary key
        public int MaPhieuNhap { get; set; }

        // Foreign key đến ProviderEntity (MANCC)
        public int MaNCC { get; set; }
        public ProviderEntity Provider { get; set; }

        // Foreign key đến Inventory (MAKHO)
        public int MaKho { get; set; }
        public Inventory Inventory { get; set; }

        // Ngày nhập - not null
        public DateTime NgayNhap { get; set; }

        // Ghi chú - nullable
        public string? GhiChu { get; set; }

        // FK property
        public ICollection<StockInDetail> StockInDetails { get; set; } = new List<StockInDetail>();
    }
}
