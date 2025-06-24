using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class RevenueDto
    {
        public int MaThu { get; set; }
        public int MaNV { get; set; }
        public DateTime NgayThu { get; set; }
        public string NoiDung { get; set; } = null!;
        public decimal SoTien { get; set; }
        public string NguoiThu { get; set; } = null!;
        public string? GhiChu { get; set; }
    }

    public class RevenueInputDto
    {
        [Required(ErrorMessage = "Mã nhân viên không được để trống")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Ngày thu không được để trống")]
        public DateTime NgayThu { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(255, ErrorMessage = "Nội dung không được vượt quá 255 ký tự")]
        public string NoiDung { get; set; } = null!;

        [Required(ErrorMessage = "Số tiền không được để trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public decimal SoTien { get; set; }

        [Required(ErrorMessage = "Người thu không được để trống")]
        [StringLength(100, ErrorMessage = "Người thu không được vượt quá 100 ký tự")]
        public string NguoiThu { get; set; } = null!;

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}
