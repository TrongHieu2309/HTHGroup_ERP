using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class DANGNHAP_BLL
    {
        private readonly NGUOIDUNG_BLL _nguoiDungBLL;

        public DANGNHAP_BLL()
        {
            _nguoiDungBLL = new NGUOIDUNG_BLL();
        }

        /// <summary>
        /// Kiểm tra thông tin đăng nhập.
        /// </summary>
        /// <param name="taiKhoan">Tên tài khoản</param>
        /// <param name="matKhau">Mật khẩu</param>
        /// <returns>Trả về UserDto nếu đăng nhập thành công, null nếu thất bại</returns>
        public async Task<UserDto?> KiemTraDangNhapAsync(string taiKhoan, string matKhau)
        {
            var loginDto = new UserLoginDto
            {
                TenDangNhap = taiKhoan,
                MatKhau = matKhau
            };

            var user = await _nguoiDungBLL.LoginAsync(loginDto);
            return user;
        }
    }
}
