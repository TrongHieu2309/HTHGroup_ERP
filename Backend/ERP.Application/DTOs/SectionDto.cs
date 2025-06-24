using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string MaBoPhan { get; set; } = null!;
        public string TenBoPhan { get; set; } = null!;
    }

    public class SectionInputDto
    {
        [Required(ErrorMessage = "Mã bộ phận không được bỏ trống")]
        [StringLength(20, ErrorMessage = "Mã bộ phận không được vượt quá 20 ký tự")]
        public string MaBoPhan { get; set; } = null!;

        [Required(ErrorMessage = "Tên bộ phận không được bỏ trống")]
        [StringLength(100, ErrorMessage = "Tên bộ phận không được vượt quá 100 ký tự")]
        public string TenBoPhan { get; set; } = null!;
    }
}
