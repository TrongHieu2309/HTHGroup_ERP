using BLL.QL_PHAN_QUYEN;
using ERP.Application.DTOs;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDANGNHAP : DevExpress.XtraEditors.XtraForm
    {
        private readonly DANGNHAP_BLL db = new DANGNHAP_BLL();
        private UserDto user;
        private string maVaiTro;

        public frmDANGNHAP()
        {
            InitializeComponent();
        }

        private async void btnDANGNHAP_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTENDN.Text.Trim();
            string matKhau = txtMATKHAU.Text.Trim();

            if (string.IsNullOrEmpty(taiKhoan) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = await db.KiemTraDangNhapAsync(taiKhoan, matKhau);

            if (user != null)
            {
                MessageBox.Show($"Đăng nhập thành công! Xin chào: {user.TenDangNhap}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                frmMAIN mainForm = new frmMAIN(user);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
