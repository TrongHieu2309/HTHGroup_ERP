using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class EmployeeAllowanceDto
    {
        public int MaPhuCapNV { get; set; }
        public int MaNV { get; set; }
        public int MaPC { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal SoTien { get; set; }
    }

    public class EmployeeAllowanceInputDto
    {
        [Required(ErrorMessage = "Mã nhân viên không được bỏ trống")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Mã phụ cấp không được bỏ trống")]
        public int MaPC { get; set; }

        [Range(1, 12, ErrorMessage = "Tháng phải từ 1 đến 12")]
        public int Thang { get; set; }

        [Range(2000, 2100, ErrorMessage = "Năm không hợp lệ")]
        public int Nam { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn hoặc bằng 0")]
        public decimal SoTien { get; set; }
    }
}
