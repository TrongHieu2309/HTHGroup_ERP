using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class InventoryDto
    {
        public int MaKho { get; set; }
        public string TenKho { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public string NguoiQuanLy { get; set; } = null!;
        public string? GhiChu { get; set; }
    }

    public class InventoryInputDto
    {
        [Required(ErrorMessage = "Tên kho là bắt buộc")]
        [StringLength(100)]
        public string TenKho { get; set; } = null!;

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [StringLength(255)]
        public string DiaChi { get; set; } = null!;

        [Required(ErrorMessage = "Người quản lý là bắt buộc")]
        [StringLength(100)]
        public string NguoiQuanLy { get; set; } = null!;

        [StringLength(255)]
        public string? GhiChu { get; set; }
    }
}
