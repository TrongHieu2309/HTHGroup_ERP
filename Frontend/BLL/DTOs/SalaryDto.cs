using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class SalaryDto
    {
        public int MaLuong { get; set; }
        public int MaNV { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal TongTC { get; set; }
        public decimal TongPC { get; set; }
        public decimal ThucLinh { get; set; }
    }

    public class SalaryInputDto
    {
        [Required]
        public int MaNV { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Tháng phải từ 1 đến 12")]
        public int Thang { get; set; }

        [Required]
        [Range(2000, 3000, ErrorMessage = "Năm không hợp lệ")]
        public int Nam { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Lương cơ bản phải > 0")]
        public decimal LuongCoBan { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TongTC { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TongPC { get; set; }
    }
}
