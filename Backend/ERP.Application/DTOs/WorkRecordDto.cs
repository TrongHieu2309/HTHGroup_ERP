using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class WorkRecordDto
    {
        public int MaTinhCong { get; set; }
        public DateTime Ngay { get; set; }
        public TimeSpan GioVao { get; set; }
        public TimeSpan GioRa { get; set; }
        public int MaNhanVien { get; set; }
        public int MaLoaiCong { get; set; }

        // Dữ liệu từ bảng Employee
        public string HoTenNhanVien { get; set; } = string.Empty;
    }

    public class WorkRecordInputDto
    {
        [Required]
        public DateTime Ngay { get; set; }

        [Required]
        public TimeSpan GioVao { get; set; }

        [Required]
        public TimeSpan GioRa { get; set; }

        [Required]
        public int MaNhanVien { get; set; }

        [Required]
        public int MaLoaiCong { get; set; }
    }
}
