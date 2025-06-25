using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ProviderDto
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string MoTa { get; set; } = null!;
        public string SoDienThoai { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NguoiTiepNhan { get; set; } = null!;
    }

    public class ProviderInputDto
    {
        [Required(ErrorMessage = "Tên NCC không được bỏ trống")]
        public string TenNCC { get; set; } = null!;

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string DiaChi { get; set; } = null!;

        [Required(ErrorMessage = "Mô tả không được bỏ trống")]
        public string MoTa { get; set; } = null!;

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải đúng 10 chữ số và không chứa ký tự đặc biệt")]
        public string SoDienThoai { get; set; } = null!;

        [Required(ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Người tiếp nhận không được bỏ trống")]
        public string NguoiTiepNhan { get; set; } = null!;
    }
}
