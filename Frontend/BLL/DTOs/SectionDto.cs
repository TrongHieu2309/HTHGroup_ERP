using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class SectionDto
    {
        public int MaBoPhan { get; set; }
        public string TenBoPhan { get; set; } = null!;
    }

    public class SectionInputDto
    {
        [Required(ErrorMessage = "Tên bộ phận không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên bộ phận không được vượt quá 100 ký tự")]
        public string TenBoPhan { get; set; } = null!;
    }
}
