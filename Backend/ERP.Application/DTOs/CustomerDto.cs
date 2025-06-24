using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class CustomerDto
    {
        public int MaKH { get; set; }
        public string TenKhachHang { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string SoDienThoai { get; set; } = null!;
        public string? Email { get; set; }
        public string? GhiChu { get; set; }
        public int TichDiem { get; set; }
    }

    public class CustomerInputDto
    {
        [Required(ErrorMessage = "Tên khách hàng không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên khách hàng không được vượt quá 100 ký tự")]
        public string TenKhachHang { get; set; } = null!;

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [StringLength(255, ErrorMessage = "Địa chỉ không được vượt quá 255 ký tự")]
        public string DiaChi { get; set; } = null!;

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại phải có 10 hoặc 11 chữ số và không chứa ký tự đặc biệt")]
        public string SoDienThoai { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự")]
        public string? Email { get; set; }

        [StringLength(255, ErrorMessage = "Ghi chú không được vượt quá 255 ký tự")]
        public string? GhiChu { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Tích điểm phải là số không âm")]
        public int TichDiem { get; set; } = 0;
    }
}
