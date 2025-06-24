using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class AuthorisationDto
    {
        public int MaQuyen { get; set; }
        public string TenQuyen { get; set; } = null!;
    }

    public class AuthorisationInputDto
    {
        [Required(ErrorMessage = "Tên quyền không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên quyền không được vượt quá 100 ký tự")]
        public string TenQuyen { get; set; } = null!;
    }
}
