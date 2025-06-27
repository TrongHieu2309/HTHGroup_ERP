using BLL.QL_NHAN_SU;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCHUCVU : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;

        public frmCHUCVU()
        {
            InitializeComponent();
        }

        private async Task LoadJobTitleListAsync()
        {
            var bll = new CHUCVU_BLL();
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

        private void _groupEmpty()
        {
            txtMACV.Text = string.Empty;
            txtTENCV.Text = string.Empty;
        }

        private async void frmCHUCVU_Load(object sender, EventArgs e)
        {
            await LoadJobTitleListAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmCHUCVU_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 90;
            splitContainer2.SplitterDistance = 180;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
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
            if (int.TryParse(txtMACV.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var bll = new CHUCVU_BLL();
                    var result = await bll.DeleteAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadJobTitleListAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var bll = new CHUCVU_BLL();

            var dto = new JobTitleInputDto
            {
                TenChucVu = txtTENCV.Text.Trim()
            };

            string result;

            if (isEditMode && int.TryParse(txtMACV.Text, out int id))
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

            await LoadJobTitleListAsync();
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
                    var job = view.GetRow(e.RowHandle) as JobTitleDto;
                    if (job != null)
                    {
                        txtMACV.Text = job.MaChucVu.ToString();
                        txtTENCV.Text = job.TenChucVu;
                    }
                }
            }
        }
    }
}
