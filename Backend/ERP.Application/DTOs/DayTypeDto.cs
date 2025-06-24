using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class DayTypeDto
    {
        public int MaLoaiCong { get; set; }
        public string TenLoaiCong { get; set; } = null!;
        public float HeSo { get; set; }
    }

    public class DayTypeInputDto
    {
        [Required(ErrorMessage = "Tên loại công không được để trống")]
        [StringLength(100, ErrorMessage = "Tên loại công tối đa 100 ký tự")]
        public string TenLoaiCong { get; set; } = null!;

        [Required(ErrorMessage = "Hệ số không được để trống")]
        [Range(0.1, 100, ErrorMessage = "Hệ số phải lớn hơn 0")]
        public float HeSo { get; set; }
    }
}
