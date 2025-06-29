using BLL.QL_NHAP_KHO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO
{
    public partial class frmPHANLOAIMATHANG : DevExpress.XtraEditors.XtraForm
    {
        private readonly PHANLOAIMATHANG_BLL phanLoaiService = new PHANLOAIMATHANG_BLL();
        private bool isNew = false;
        private int selectedId = -1;

        public frmPHANLOAIMATHANG()
        {
            InitializeComponent();
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
            txtMAMATHANG.Text = string.Empty;
            txtTENMATHANG.Text = string.Empty;
            txtSOLUONG.Text = string.Empty;
            txtTONGCHIPHI.Text = string.Empty;
        }

        async void LoadData()
        {
            var data = await phanLoaiService.GetAllAsync();
            gridControl1.DataSource = data;
        }

        private async void frmPHANLOAIMATHANG_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            LoadData();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isNew = true;
            groupNhap.Enabled = true;
            _groupEmpty();
            _showHide(false);
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần sửa.");
                return;
            }

            isNew = false;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa mặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string msg = await phanLoaiService.DeleteAsync(selectedId);
                MessageBox.Show(msg);
                LoadData();
                _groupEmpty();
                _showHide(true);
                selectedId = -1;
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTENMATHANG.Text) ||
                string.IsNullOrWhiteSpace(txtSOLUONG.Text) ||
                string.IsNullOrWhiteSpace(txtTONGCHIPHI.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (!int.TryParse(txtSOLUONG.Text, out int soLuong) ||
                !long.TryParse(txtTONGCHIPHI.Text, out long tongChiPhi))
            {
                MessageBox.Show("Số lượng và tổng chi phí phải là số hợp lệ.");
                return;
            }

            var input = new ProductCategoryInputDto
            {
                TenMatHang = txtTENMATHANG.Text.Trim(),
                SoLuong = soLuong,
                TongChiPhi = tongChiPhi
            };

            string msg;
            if (isNew)
            {
                msg = await phanLoaiService.CreateAsync(input);
            }
            else
            {
                msg = await phanLoaiService.UpdateAsync(selectedId, input);
            }

            MessageBox.Show(msg);
            LoadData();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            selectedId = -1;
            isNew = false;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            selectedId = -1;
            isNew = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            var view = sender as GridView;
            if (view != null && e.RowHandle >= 0)
            {
                var row = view.GetRow(e.RowHandle) as dynamic;
                if (row != null)
                {
                    txtMAMATHANG.Text = row.MaMatHang.ToString();
                    txtTENMATHANG.Text = row.TenMatHang;
                    txtSOLUONG.Text = row.SoLuong.ToString();
                    txtTONGCHIPHI.Text = row.TongChiPhi.ToString();

                    selectedId = row.MaMatHang;
                    barbtnSua.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnHuybo.Enabled = true;
                }
            }
        }
    }
}
