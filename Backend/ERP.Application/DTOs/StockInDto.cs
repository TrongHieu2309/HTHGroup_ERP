using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class StockInDto
    {
        public int MaPhieuNhap { get; set; } // Mã phiếu nhập
        public int MaNCC { get; set; } // Mã nhà cung cấp
        public int MaKho { get; set; } // Mã kho
        public DateTime NgayNhap { get; set; } // Ngày nhập
        public string? GhiChu { get; set; } // Ghi chú (có thể null)
    }

    public class StockInInputDto
    {
        [Required(ErrorMessage = "Mã nhà cung cấp không được bỏ trống")]
        public int MaNCC { get; set; }

        [Required(ErrorMessage = "Mã kho không được bỏ trống")]
        public int MaKho { get; set; }

        [Required(ErrorMessage = "Ngày nhập không được bỏ trống")]
        public DateTime NgayNhap { get; set; }

        [StringLength(255, ErrorMessage = "Ghi chú không được vượt quá 255 ký tự")]
        public string? GhiChu { get; set; }
    }
}
