using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ProductCategoryDto
    {
        public int MaMatHang { get; set; }
        public string TenMatHang { get; set; } = null!;
        public int SoLuong { get; set; }
        public long TongChiPhi { get; set; }
    }

    public class ProductCategoryInputDto
    {
        [Required(ErrorMessage = "Tên mặt hàng là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên mặt hàng tối đa 100 ký tự")]
        public string TenMatHang { get; set; } = null!;

        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là số không âm")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Tổng chi phí là bắt buộc")]
        [Range(0, long.MaxValue, ErrorMessage = "Tổng chi phí phải là số không âm")]
        public long TongChiPhi { get; set; }
    }
}
