using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string MaPhongBan { get; set; } = null!;
        public string TenPhongBan { get; set; } = null!;
    }

    public class DepartmentInputDto
    {
        [Required(ErrorMessage = "Mã phòng ban không được bỏ trống")]
        [MaxLength(20, ErrorMessage = "Mã phòng ban tối đa 20 ký tự")]
        public string MaPhongBan { get; set; } = null!;

        [Required(ErrorMessage = "Tên phòng ban không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Tên phòng ban tối đa 100 ký tự")]
        public string TenPhongBan { get; set; } = null!;
    }
}
