namespace ERP.Core.Entities
{
    public class ExtraShift
    {
        // bảng tăng ca
        public int MaTangCa { get; set; } // PK
        public DateTime Ngay { get; set; } // Ngày tăng ca, date not null, ko có giờ
        public int SoGio { get; set; } // Số giờ tăng ca, int not null

        // FK MaNV → Employee.MaNV
        public int MaNV { get; set; } // FK đến Employee
        public Employee Employee { get; set; } = null!; // Navigation property to Employee

        // FK MaLoaiCa → ShiftType.MaLoaiCa
        public int MaLoaiCa { get; set; } // FK đến ShiftType
        public ShiftType ShiftType { get; set; } = null!; // Navigation property to ShiftType
    }
}
