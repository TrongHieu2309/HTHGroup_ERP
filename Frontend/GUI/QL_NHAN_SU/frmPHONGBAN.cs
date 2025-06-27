using BLL.QL_NHAN_SU;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmPHONGBAN : DevExpress.XtraEditors.XtraForm
    {
        public frmPHONGBAN()
        {
            InitializeComponent();
        }

        private bool isEditMode = false;

        private async Task LoadDataAsync()
        {
            var bll = new PHONGBAN_BLL();
            var list = await bll.GetAllAsync();
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
            txtMAPB.Text = string.Empty;
            txtTENPB.Text = string.Empty;
        }

        private async void frmPHONGBAN_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmPHONGBAN_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 93;
            splitContainer2.SplitterDistance = 154;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            groupNhap.Enabled = true;
            _showHide(false);
            _groupEmpty();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = true;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtMAPB.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var bll = new PHONGBAN_BLL();
                    var result = await bll.DeleteAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var bll = new PHONGBAN_BLL();

            var dto = new DepartmentInputDto
            {
                TenPhongBan = txtTENPB.Text.Trim()
            };

            string result;

            if (isEditMode && int.TryParse(txtMAPB.Text, out int id))
            {
                // Cập nhật
                result = await bll.UpdateAsync(id, dto);
            }
            else
            {
                // Thêm mới
                result = await bll.AddAsync(dto);
            }

            MessageBox.Show(result, "Thông báo");

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmNHANSU nhansuForm)
                {
                    await nhansuForm.LoadComboBoxAsync();
                    break;
                }
            }

            await LoadDataAsync();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
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
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            barbtnHuybo.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var phongban = view.GetRow(e.RowHandle) as DepartmentDto;
                    if (phongban != null)
                    {
                        txtMAPB.Text = phongban.MaPhongBan.ToString();
                        txtTENPB.Text = phongban.TenPhongBan;
                    }
                }
            }
        }
    }
}
