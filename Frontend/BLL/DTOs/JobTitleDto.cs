using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class JobTitleDto
    {
        public int MaChucVu { get; set; }
        public string TenChucVu { get; set; } = null!;
    }

    public class JobTitleInputDto
    {
        [Required(ErrorMessage = "Tên chức vụ là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên chức vụ không vượt quá 100 ký tự")]
        public string TenChucVu { get; set; } = null!;
    }
}
