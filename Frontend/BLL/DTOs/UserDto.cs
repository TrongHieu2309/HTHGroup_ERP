using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string TenDangNhap { get; set; } = null!;
        public string MaVaiTro { get; set; } = null!;
    }

    public class UserLoginDto
    {
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
    }

    public class UserRegisterDto
    {
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string MaVaiTro { get; set; } = null!;
    }

    public class UserUpdateDto
    {
        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; } = null!;

        [Required]
        [StringLength(10)]
        public string MaVaiTro { get; set; } = null!;
    }
}
