using BLL.QL_KHACH_HANG;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_KHACH_HANG
{
    public partial class frmKHACHHANG : DevExpress.XtraEditors.XtraForm
    {
        public frmKHACHHANG()
        {
            InitializeComponent();
        }

        private bool isEditMode = false;

        private async Task LoadCustomerListAsync()
        {
            var bll = new KHACHHANG_BLL();
            var list = await bll.GetAllCustomersAsync();
            gridControl1.DataSource = list;
        }


        void _showHide(bool kt)
        {
            barbtnThem.Enabled = kt;
            barbtnSua.Enabled = !kt;
            barbtnXoa.Enabled = !kt;
            barbtnLuu.Enabled = !kt;
            barbtnHuybo.Enabled = !kt;
        }

        void _groupEmpty()
        {
            txtMAKH.Text = string.Empty;
            txtTENKH.Text = string.Empty;
            txtDIACHI.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEMAIL.Text = string.Empty;
            txtGHICHU.Text = string.Empty;
            txtTICHDIEM.Text = string.Empty;
        }

        private async void frmKHACHHANG_Load(object sender, EventArgs e)
        {
            await LoadCustomerListAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmKHACHHANG_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 160;
            splitContainer4.SplitterDistance = 122;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            groupNhap.Enabled = true;
            _groupEmpty();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = true;
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            barbtnHuybo.Enabled = true;
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtMAKH.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var bll = new KHACHHANG_BLL();
                    var result = await bll.DeleteCustomerAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadCustomerListAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }


        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var bll = new KHACHHANG_BLL();

            var dto = new CustomerDto
            {
                MaKH = int.TryParse(txtMAKH.Text, out var id) ? id : 0,
                TenKhachHang = txtTENKH.Text.Trim(),
                DiaChi = txtDIACHI.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                Email = txtEMAIL.Text.Trim(),
                GhiChu = txtGHICHU.Text.Trim(),
                TichDiem = int.TryParse(txtTICHDIEM.Text, out var diem) ? diem : 0
            };

            string result;

            if (isEditMode && dto.MaKH > 0)
            {
                // Nếu đang trong chế độ sửa và có mã khách hàng > 0 => gọi API cập nhật
                result = await bll.UpdateCustomerAsync(dto.MaKH, dto);
            }
            else
            {
                // Ngược lại => thêm mới
                result = await bll.CreateCustomerAsync(dto);
            }

            MessageBox.Show(result, "Thông báo");

            await LoadCustomerListAsync();
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }


        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }


        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var khachhang = view.GetRow(e.RowHandle) as CustomerDto;
                    if (khachhang != null)
                    {
                        txtMAKH.Text = khachhang.MaKH.ToString();
                        txtTENKH.Text = khachhang.TenKhachHang;
                        txtDIACHI.Text = khachhang.DiaChi;
                        txtSDT.Text = khachhang.SoDienThoai;
                        txtEMAIL.Text = khachhang.Email;
                        txtGHICHU.Text = khachhang.GhiChu;
                        txtTICHDIEM.Text = khachhang.TichDiem.ToString();
                    }
                }
            }
        }
    }
}