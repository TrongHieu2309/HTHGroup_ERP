using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class StockInDetailDto
    {
        public int Id { get; set; }
        public int MaPhieuNhap { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; } = null!;
        public int SoLuongNhap { get; set; }
        public long DonGia { get; set; }
    }

    public class StockInDetailInputDto
    {
        [Required]
        public int MaPhieuNhap { get; set; }

        [Required]
        public int MaSP { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng nhập phải lớn hơn 0")]
        public int SoLuongNhap { get; set; }

        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 0")]
        public long DonGia { get; set; }
    }
}
