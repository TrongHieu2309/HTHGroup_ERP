using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class DepartmentDto
    {
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; } = null!;
    }

    public class DepartmentInputDto
    {
        [Required(ErrorMessage = "Tên phòng ban không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên phòng ban tối đa 100 ký tự")]
        public string TenPhongBan { get; set; } = null!;
    }
}
