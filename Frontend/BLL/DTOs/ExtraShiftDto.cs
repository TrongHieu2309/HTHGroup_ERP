using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class ExtraShiftDto
    {
        public int MaTangCa { get; set; }
        public DateTime Ngay { get; set; }
        public int SoGio { get; set; }

        public int MaNV { get; set; }
        public string HoTenNV { get; set; } = null!;

        public int MaLoaiCa { get; set; }
        public string CaLamViec { get; set; } = null!;
    }

    public class ExtraShiftInputDto
    {
        [Required(ErrorMessage = "Ngày tăng ca không được bỏ trống")]
        public DateTime Ngay { get; set; }

        [Required(ErrorMessage = "Số giờ tăng ca không được bỏ trống")]
        [Range(1, 24, ErrorMessage = "Số giờ tăng ca phải nằm trong khoảng 1 đến 24")]
        public int SoGio { get; set; }

        [Required(ErrorMessage = "Mã nhân viên là bắt buộc")]
        public int MaNV { get; set; }

        [Required(ErrorMessage = "Mã loại ca là bắt buộc")]
        public int MaLoaiCa { get; set; }
    }
}
