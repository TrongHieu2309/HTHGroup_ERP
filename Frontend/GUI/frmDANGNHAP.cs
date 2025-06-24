using BLL.QL_PHAN_QUYEN;
using DAL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDANGNHAP : DevExpress.XtraEditors.XtraForm
    {
        public frmDANGNHAP()
        {
            InitializeComponent();
        }
        private DANGNHAP_BLL db = new DANGNHAP_BLL();

        private void btnDANGNHAP_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTENDN.Text.Trim();
            string matKhau = txtMATKHAU.Text.Trim();

            NGUOIDUNG nguoiDung = db.KiemTraDangNhap(taiKhoan, matKhau);

            if (nguoiDung != null)
            {
                MessageBox.Show($"Đăng nhập thành công! Xin chào: {nguoiDung.TEN_ND}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                frmMAIN mainForm = new frmMAIN();
                
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}