namespace ERP.Core.Entities
{
    public class Receipt
    {
        // MaHD: Primary Key
        public int MaHD { get; set; }

        // MaKH: FK đến Customer (MaKH)
        public int MaKH { get; set; }
        public Customer Customer { get; set; } = null!;

        // LoaiHD: nvarchar(50), not null
        public string LoaiHD { get; set; } = null!;

        // NgayLap: datetime, not null
        public DateTime NgayLap { get; set; }

        // NguoiLap: nvarchar(100), not null
        public string NguoiLap { get; set; } = null!;

        // TongTien: bigint, not null
        public long TongTien { get; set; }

        // TrangThai: nvarchar(20), not null
        public string TrangThai { get; set; } = null!;

        public ICollection<ReceiptDetail> ReceiptDetails { get; set; } = new List<ReceiptDetail>();
    }
}
