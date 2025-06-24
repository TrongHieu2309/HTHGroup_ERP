namespace ERP.Core.Entities
{
    public class Revenue
    {
        // Bảng Thu
        public int MaThu { get; set; } // PK

        // FK MaNV → Employee.MaNV
        public int MaNV { get; set; }
        public Employee Employee { get; set; } = null!; // Navigation property to Employee

        public DateTime NgayThu { get; set; } // Ngày thu, date not null, không có giờ
        public string NoiDung { get; set; } = null!; // nvarchar 255 not null
        public decimal SoTien { get; set; } // decimal(18,2) not null
        public string NguoiThu { get; set; } = null!; // nvarchar 100 not null
        public string? GhiChu { get; set; } // nvarchar 255, nullable
    }
}
