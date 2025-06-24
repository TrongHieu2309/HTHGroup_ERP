using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class RolesDto
    {
        public string MaVaiTro { get; set; } = null!;
        public string TenVaiTro { get; set; } = null!;
    }

    public class RolesInputDto
    {
        [Required(ErrorMessage = "Mã vai trò không được bỏ trống")]
        [StringLength(10, ErrorMessage = "Mã vai trò không được vượt quá 10 ký tự")]
        public string MaVaiTro { get; set; } = null!;

        [Required(ErrorMessage = "Tên vai trò không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên vai trò không được vượt quá 100 ký tự")]
        public string TenVaiTro { get; set; } = null!;
    }
}
