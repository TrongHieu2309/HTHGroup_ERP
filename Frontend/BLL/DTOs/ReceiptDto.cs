using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ReceiptDto
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public string LoaiHD { get; set; } = null!;
        public DateTime NgayLap { get; set; }
        public string NguoiLap { get; set; } = null!;
        public long TongTien { get; set; }
        public string TrangThai { get; set; } = null!;
    }

    public class ReceiptInputDto
    {
        [Required(ErrorMessage = "Mã khách hàng không được để trống")]
        public int MaKH { get; set; }

        [Required(ErrorMessage = "Loại hóa đơn không được để trống")]
        [StringLength(50, ErrorMessage = "Loại hóa đơn tối đa 50 ký tự")]
        public string LoaiHD { get; set; } = null!;

        [Required(ErrorMessage = "Ngày lập không được để trống")]
        public DateTime NgayLap { get; set; }

        [Required(ErrorMessage = "Người lập không được để trống")]
        [StringLength(100, ErrorMessage = "Người lập tối đa 100 ký tự")]
        public string NguoiLap { get; set; } = null!;

        [Required(ErrorMessage = "Tổng tiền không được để trống")]
        [Range(0, long.MaxValue, ErrorMessage = "Tổng tiền phải lớn hơn hoặc bằng 0")]
        public long TongTien { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        [StringLength(20, ErrorMessage = "Trạng thái tối đa 20 ký tự")]
        public string TrangThai { get; set; } = null!;
    }
}
