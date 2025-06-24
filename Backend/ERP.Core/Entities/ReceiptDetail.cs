namespace ERP.Core.Entities
{
    public class ReceiptDetail
    {
        public int Id { get; set; } // primary key

        // FK: MaHD → Receipt.MaHD
        public int MaHD { get; set; }
        public Receipt Receipt { get; set; } = null!;

        // FK: MaSP → Product.MaSP
        public int MaSP { get; set; }
        public Product Product { get; set; } = null!;

        public int SoLuong { get; set; } // int not null

        public long DonGia { get; set; } // bigint not null

        public float ChietKhau { get; set; } = 0f; // float, default 0

        public float VAT { get; set; } = 0.1f; // float, default 0.1

        public string? GhiChu { get; set; } // nvarchar(255), nullable
    }
}
