using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class AllowanceDto
    {
        public int MaPC { get; set; } // Mã phụ cấp
        public string TenPhuCap { get; set; } = null!; // Tên phụ cấp
        public decimal SoTien { get; set; } // Số tiền
    }

    public class AllowanceInputDto
    {
        [Required(ErrorMessage = "Tên phụ cấp không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên phụ cấp không được vượt quá 100 ký tự")]
        public string TenPhuCap { get; set; } = null!;

        [Required(ErrorMessage = "Số tiền không được bỏ trống")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền phải là số hợp lệ và lớn hơn 0")]
        public decimal SoTien { get; set; }
    }
}