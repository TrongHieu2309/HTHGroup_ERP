using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ReceiptDetailDto
    {
        public int Id { get; set; }
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public long DonGia { get; set; }
        public float ChietKhau { get; set; }
        public float VAT { get; set; }
        public string? GhiChu { get; set; }
    }

    public class ReceiptDetailInputDto
    {
        [Required]
        public int MaHD { get; set; }

        [Required]
        public int MaSP { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int SoLuong { get; set; }

        [Required]
        [Range(0, long.MaxValue, ErrorMessage = "Đơn giá không hợp lệ")]
        public long DonGia { get; set; }

        [Range(0.0, 1.0, ErrorMessage = "Chiết khấu phải từ 0 đến 1")]
        public float ChietKhau { get; set; } = 0.0f;

        [Range(0.0, 1.0, ErrorMessage = "VAT phải từ 0 đến 1")]
        public float VAT { get; set; } = 0.0f;

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}
