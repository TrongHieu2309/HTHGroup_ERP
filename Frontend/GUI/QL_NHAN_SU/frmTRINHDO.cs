using BLL.QL_KHACH_HANG;
using BLL.QL_TRINH_DO;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTRINHDO : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;

        public frmTRINHDO()
        {
            InitializeComponent();
        }

        private async Task LoadTrinhDoListAsync()
        {
            var bll = new TRINHDO_BLL();
            var list = await bll.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private void _showHide(bool kt)
        {
            barbtnThem.Enabled = kt;
            barbtnSua.Enabled = !kt;
            barbtnXoa.Enabled = !kt;
            barbtnLuu.Enabled = !kt;
            barbtnHuybo.Enabled = !kt;
        }

        private void _clearInput()
        {
            txtMATD.Text = string.Empty;
            txtTENTD.Text = string.Empty;
        }

        private async void frmTRINHDO_Load(object sender, EventArgs e)
        {
            await LoadTrinhDoListAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            _clearInput();
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMATD.Text))
            {
                MessageBox.Show("Vui lòng chọn trình độ để sửa!", "Thông báo");
                return;
            }

            isEditMode = true;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var bll = new TRINHDO_BLL();
            var dto = new EducationLevelInputDto
            {
                TrinhDoHocVan = txtTENTD.Text.Trim()
            };

            string result;

            if (isEditMode && int.TryParse(txtMATD.Text, out var id))
            {
                result = await bll.UpdateAsync(id, dto);
            }
            else
            {
                result = await bll.CreateAsync(dto);
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

            await LoadTrinhDoListAsync();
            groupNhap.Enabled = false;
            _clearInput();
            _showHide(true);
            isEditMode = false;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupNhap.Enabled = false;
            _clearInput();
            _showHide(true);
            isEditMode = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmTRINHDO_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 96;
            splitContainer2.SplitterDistance = 182;
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtMATD.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var bll = new TRINHDO_BLL();
                    var result = await bll.DeleteAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadTrinhDoListAsync();
                    _clearInput();
                    _showHide(true);
                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            barbtnHuybo.Enabled = true;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var item = view?.GetRow(e.RowHandle) as EducationLevelDto;
                if (item != null)
                {
                    txtMATD.Text = item.MaTDHV.ToString();
                    txtTENTD.Text = item.TrinhDoHocVan;
                }
            }
        }
    }
}
