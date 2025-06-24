using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class StockOutDto
    {
        public int MaPhieuXuat { get; set; }
        public int MaKho { get; set; }
        public string NguoiXuat { get; set; } = null!;
        public DateTime NgayXuat { get; set; }
        public string? LyDoXuat { get; set; }
    }

    public class StockOutInputDto
    {
        [Required(ErrorMessage = "Mã kho là bắt buộc")]
        public int MaKho { get; set; }

        [Required(ErrorMessage = "Người xuất là bắt buộc")]
        [StringLength(100)]
        public string NguoiXuat { get; set; } = null!;

        [Required(ErrorMessage = "Ngày xuất là bắt buộc")]
        public DateTime NgayXuat { get; set; }

        [StringLength(255)]
        public string? LyDoXuat { get; set; }
    }
}
