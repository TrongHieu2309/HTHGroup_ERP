using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Application.DTOs
{
    public class EmployeeDto
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; } = null!;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = null!;
        public string SoDienThoai { get; set; } = null!;
        public string CCCD { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public int MaPhongBan { get; set; }
        public int MaBoPhan { get; set; }
        public int MaChucVu { get; set; }
        public int MaTDHV { get; set; }
    }

    public class EmployeeInputDto
    {
        [Required(ErrorMessage = "Họ tên không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        public string HoTen { get; set; } = null!;

        [Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Giới tính không được bỏ trống")]
        [MaxLength(10, ErrorMessage = "Giới tính tối đa 10 ký tự")]
        public string GioiTinh { get; set; } = null!;

        [Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Số điện thoại phải từ 10 đến 15 chữ số")]
        public string SoDienThoai { get; set; } = null!;

        [Required(ErrorMessage = "CCCD không được bỏ trống")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "CCCD phải đúng 12 chữ số")]
        public string CCCD { get; set; } = null!;

        [Required(ErrorMessage = "Email không được bỏ trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        [MaxLength(255, ErrorMessage = "Địa chỉ tối đa 255 ký tự")]
        public string DiaChi { get; set; } = null!;

        [Required(ErrorMessage = "Mã phòng ban không được bỏ trống")]
        public int MaPhongBan { get; set; }

        [Required(ErrorMessage = "Mã bộ phận không được bỏ trống")]
        public int MaBoPhan { get; set; }

        [Required(ErrorMessage = "Mã chức vụ không được bỏ trống")]
        public int MaChucVu { get; set; }

        [Required(ErrorMessage = "Mã trình độ học vấn không được bỏ trống")]
        public int MaTDHV { get; set; }
    }
}
