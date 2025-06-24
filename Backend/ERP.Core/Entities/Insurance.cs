namespace ERP.Core.Entities
{
    public class Insurance
    {
        // Bảng Bảo hiểm 
        public int MaBH { get; set; } // PK int not null

        public int MaNV { get; set; } // FK đến Employee, int not null
        public Employee Employee { get; set; } = null!; // Navigation property to Employee

        public string LoaiBH { get; set; } = null!; // varchar 10 not null
        public string SoBH { get; set; } = null!; // varchar 20 not null
        public string? BenhVien { get; set; } // nvarchar 100 nullable, tên bệnh viện
        public DateTime NgayCap { get; set; } // datetime not null
        public DateTime NgayHetHan { get; set; } // datetime not null
        public string? TinhTrang { get; set; } // nvarchar 50 nullable
    }
}
