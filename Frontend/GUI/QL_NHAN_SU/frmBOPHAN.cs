using BLL.QL_NHAN_SU;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBOPHAN : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;

        public frmBOPHAN()
        {
            InitializeComponent();
        }

        private async Task LoadSectionListAsync()
        {
            var bll = new BOPHAN_BLL();
            var list = await bll.GetAllSectionsAsync();
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
            txtMABP.Text = string.Empty;
            txtTENBP.Text = string.Empty;
        }

        private async void frmBOPHAN_Load(object sender, EventArgs e)
        {
            await LoadSectionListAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmBOPHAN_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 166;
            splitContainer1.SplitterDistance = 90;
        }

        private void barbtnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            if (int.TryParse(txtMABP.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var bll = new BOPHAN_BLL();
                    var result = await bll.DeleteSectionAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadSectionListAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var bll = new BOPHAN_BLL();

            var dto = new SectionInputDto
            {
                TenBoPhan = txtTENBP.Text.Trim()
            };

            string result;

            if (isEditMode && int.TryParse(txtMABP.Text, out int id))
            {
                result = await bll.UpdateSectionAsync(id, dto);
            }
            else
            {
                result = await bll.CreateSectionAsync(dto);
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

            await LoadSectionListAsync();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            isEditMode = false;
        }

        private void barbtnHuybo_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }

        private void barbtnThoat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                    var section = view.GetRow(e.RowHandle) as SectionDto;
                    if (section != null)
                    {
                        txtMABP.Text = section.MaBoPhan.ToString();
                        txtTENBP.Text = section.TenBoPhan;
                    }
                }
            }
        }
    }
}
