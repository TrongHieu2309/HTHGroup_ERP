using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ShiftTypeDto
    {
        public int MaLoaiCa { get; set; }
        public string CaLamViec { get; set; } = null!;
        public float HeSoTangCa { get; set; }
    }

    public class ShiftTypeInputDto
    {
        [Required(ErrorMessage = "Tên ca làm việc không được để trống")]
        [StringLength(50, ErrorMessage = "Tên ca làm việc không được vượt quá 50 ký tự")]
        public string CaLamViec { get; set; } = null!;

        [Range(1.0, float.MaxValue, ErrorMessage = "Hệ số tăng ca phải lớn hơn hoặc bằng 1.0")]
        public float HeSoTangCa { get; set; } = 1.0f;
    }
}
