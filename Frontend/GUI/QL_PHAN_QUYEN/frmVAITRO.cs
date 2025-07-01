using BLL.QL_PHAN_QUYEN;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_PHAN_QUYEN
{
    public partial class frmVAITRO : DevExpress.XtraEditors.XtraForm
    {
        public frmVAITRO()
        {
            InitializeComponent();
        }

        private bool isEditMode = false;
        private readonly VAITRO_BLL bll = new VAITRO_BLL();

        private async Task LoadDataAsync()
        {
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
            txtMAVT.Text = string.Empty;
            txtTENVT.Text = string.Empty;
        }

        private async void frmVAITRO_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmVAITRO_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 101;
            splitContainer2.SplitterDistance = 184;
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
            txtMAVT.Enabled = false;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var maVaiTro = txtMAVT.Text.Trim();
            if (!string.IsNullOrEmpty(maVaiTro))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await bll.DeleteAsync(maVaiTro);
                    MessageBox.Show(result, "Thông báo");
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dto = new RolesInputDto
            {
                MaVaiTro = txtMAVT.Text.Trim(),
                TenVaiTro = txtTENVT.Text.Trim()
            };

            string result;

            if (isEditMode)
            {
                result = await bll.UpdateAsync(dto.MaVaiTro, dto);
            }
            else
            {
                result = await bll.AddAsync(dto);
            }

            MessageBox.Show(result, "Thông báo");
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
                var vaitro = view.GetRow(e.RowHandle) as RolesDto;
                if (vaitro != null)
                {
                    txtMAVT.Text = vaitro.MaVaiTro;
                    txtTENVT.Text = vaitro.TenVaiTro;
                }
            }
        }
    }
}
