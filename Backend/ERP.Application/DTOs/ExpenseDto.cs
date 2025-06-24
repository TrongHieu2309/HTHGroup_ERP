using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ExpenseDto
    {
        public int MaChi { get; set; }
        public int MaNV { get; set; }
        public string HoTenNV { get; set; } = null!; // Tên nhân viên từ navigation property
        public DateTime NgayChi { get; set; }
        public string NoiDung { get; set; } = null!;
        public decimal SoTien { get; set; }
        public string NguoiChi { get; set; } = null!;
        public string? GhiChu { get; set; }
    }

    public class ExpenseInputDto
    {
        [Required(ErrorMessage = "Mã nhân viên không được bỏ trống")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Ngày chi không được bỏ trống")]
        public DateTime NgayChi { get; set; }

        [Required(ErrorMessage = "Nội dung không được bỏ trống")]
        [StringLength(255)]
        public string NoiDung { get; set; } = null!;

        [Required(ErrorMessage = "Số tiền không được bỏ trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        public decimal SoTien { get; set; }

        [Required(ErrorMessage = "Người chi không được bỏ trống")]
        [StringLength(100)]
        public string NguoiChi { get; set; } = null!;

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}
