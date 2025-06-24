namespace ERP.Core.Entities
{
    public class WorkRecord
    {
        // Bảng Tính công
        public int MaTinhCong { get; set; } // PK

        public DateTime Ngay { get; set; } // Ngày chấm công (datetime not null)

        public TimeSpan GioVao { get; set; } // Giờ vào (time not null)

        public TimeSpan GioRa { get; set; } // Giờ ra (time not null)

        public int MaNhanVien { get; set; } // FK đến Employee

        public int MaLoaiCong { get; set; } // FK đến DayType

        // Navigation properties
        public Employee Employee { get; set; } = null!;
        public DayType DayType { get; set; } = null!;
    }
}
