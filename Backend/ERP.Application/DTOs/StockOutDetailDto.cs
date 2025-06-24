using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class StockOutDetailDto
    {
        public int Id { get; set; }
        public int MaPhieuXuat { get; set; }
        public int MaSP { get; set; }
        public int SoLuongXuat { get; set; }
        public string? GhiChu { get; set; }

        public string? TenSanPham { get; set; }
    }

    public class StockOutDetailInputDto
    {
        [Required]
        public int MaPhieuXuat { get; set; }

        [Required]
        public int MaSP { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int SoLuongXuat { get; set; }

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}
