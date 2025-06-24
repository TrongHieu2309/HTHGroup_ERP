namespace ERP.Core.Entities
{
    public class Expense
    {
        // Bảng Chi
        public int MaChi { get; set; } // PK

        // FK MaNV → Employee.MaNV
        public int MaNV { get; set; } // FK đến Employee
        public Employee Employee { get; set; } = null!; // Navigation property to Employee

        public DateTime NgayChi { get; set; } // Ngày chi, date not null, không có giờ
        public string NoiDung { get; set; } = null!; // nvarchar 255 not null
        public decimal SoTien { get; set; } // decimal(18,2) not null, số tiền chi
        public string NguoiChi { get; set; } = null!; // nvarchar 100 not null, người chi
        public string? GhiChu { get; set; } // nvarchar 255, nullable
    }
}
