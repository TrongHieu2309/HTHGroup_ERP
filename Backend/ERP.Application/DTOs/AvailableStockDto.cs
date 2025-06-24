using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class AvailableStockDto
    {
        public int Id { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; } = null!;
        public int MaKho { get; set; }
        public int SoLuongTon { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }

    public class AvailableStockInputDto
    {
        [Required]
        public int MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSP { get; set; } = null!;

        [Required]
        public int MaKho { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int SoLuongTon { get; set; }

        public DateTime? NgayCapNhat { get; set; }
    }
}
