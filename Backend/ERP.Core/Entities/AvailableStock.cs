namespace ERP.Core.Entities
{
    public class AvailableStock
    {
        public int Id { get; set; }
        public int MaSP { get; set; }       // FK → Product
        public string TenSP { get; set; } = null!; // not null
        public int MaKho { get; set; }      // FK → Inventory

        public int SoLuongTon { get; set; } // not null
        public DateTime? NgayCapNhat { get; set; }

        // Navigation properties
        public Product Product { get; set; } = null!;
        public Inventory Inventory { get; set; } = null!;
    }
}
