using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ProductDto
    {
        public int MaSP { get; set; }
        public string TenSanPham { get; set; } = null!;
        public string? MoTa { get; set; }
        public int MaNCC { get; set; }
        public int MaMatHang { get; set; }
        public long DonGia { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime NgayNhap { get; set; }
        public string TrangThai { get; set; } = null!;
    }

    public class ProductInputDto
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
        public string TenSanPham { get; set; } = null!;

        [StringLength(255, ErrorMessage = "Mô tả tối đa 255 ký tự")]
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp không được để trống")]
        public int MaNCC { get; set; }

        [Required(ErrorMessage = "Mã mặt hàng không được để trống")]
        public int MaMatHang { get; set; }

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(0, long.MaxValue, ErrorMessage = "Đơn giá phải là số không âm")]
        public long DonGia { get; set; }

        [Required(ErrorMessage = "Số lượng tồn không được để trống")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng tồn phải là số không âm")]
        public int SoLuongTon { get; set; }

        [Required(ErrorMessage = "Ngày nhập không được để trống")]
        public DateTime NgayNhap { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        [StringLength(10, ErrorMessage = "Trạng thái tối đa 10 ký tự")]
        public string TrangThai { get; set; } = null!;
    }
}
