using BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using GUI.QL_TAI_CHINH_GUI;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_TAICHINH
{
    public partial class frmPHUCAP : DevExpress.XtraEditors.XtraForm
    {
        private readonly PHUCAP_BLL db = new PHUCAP_BLL();
        private bool isEditMode = false;

        public frmPHUCAP()
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
            txtMAPC.Text = string.Empty;
            txtTENPC.Text = string.Empty;
            txtSOTIEN.Text = string.Empty;
        }

        private async Task LoadDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmPHUCAP_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmPHUCAP_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 120;
            splitContainer2.SplitterDistance = 135;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            _groupEmpty();
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = true;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtMAPC.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await db.DeleteAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTENPC.Text) || string.IsNullOrWhiteSpace(txtSOTIEN.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            if (!decimal.TryParse(txtSOTIEN.Text, out decimal sotien))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo");
                return;
            }

            var input = new AllowanceInputDto
            {
                TenPhuCap = txtTENPC.Text.Trim(),
                SoTien = sotien
            };

            string result;

            if (isEditMode && int.TryParse(txtMAPC.Text, out int id))
            {
                result = await db.UpdateAsync(id, input);
            }
            else
            {
                result = await db.CreateAsync(input);
            }

            MessageBox.Show(result, "Thông báo");

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmPHUCAPNV phucapNVForm)
                {
                    await phucapNVForm.LoadComboDataAsync();
                    break;
                }
            }

            await LoadDataAsync();
            _groupEmpty();
            groupNhap.Enabled = false;
            _showHide(true);
            isEditMode = false;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _groupEmpty();
            groupNhap.Enabled = false;
            _showHide(true);
            isEditMode = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as AllowanceDto;
                if (data != null)
                {
                    txtMAPC.Text = data.MaPC.ToString();
                    txtTENPC.Text = data.TenPhuCap;
                    txtSOTIEN.Text = data.SoTien.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                }
            }
        }
    }
}
