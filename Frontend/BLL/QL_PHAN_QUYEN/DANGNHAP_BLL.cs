using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <returns>Trả về đối tượng NGUOIDUNG nếu đúng, null nếu sai</returns>
        public NGUOIDUNG KiemTraDangNhap(string taiKhoan, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(taiKhoan) || string.IsNullOrWhiteSpace(matKhau))
                return null;

            var danhSachNguoiDung = _nguoiDungBLL.GetList();

            var nguoiDung = danhSachNguoiDung
                .FirstOrDefault(nd => nd.TEN_ND == taiKhoan && nd.MATKHAU == matKhau);

            return nguoiDung;
        }
    }
}