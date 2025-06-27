using BLL;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHANSU
{
    public partial class frmLOAICONG : DevExpress.XtraEditors.XtraForm
    {
        private readonly LOAICONG_BLL db = new LOAICONG_BLL();
        private bool isEditMode = false;

        public frmLOAICONG()
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
            txtMALC.Text = string.Empty;
            txtTENLC.Text = string.Empty;
            txtHESO.Text = string.Empty;
        }

        private async Task LoadDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmLOAICONG_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmLOAICONG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 123;
            splitContainer2.SplitterDistance = 160;
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
            if (int.TryParse(txtMALC.Text, out int id))
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
            if (!float.TryParse(txtHESO.Text.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out float heso))
            {
                MessageBox.Show("Hệ số tăng ca không hợp lệ!");
                return;
            }

            var input = new DayTypeInputDto
            {
                TenLoaiCong = txtTENLC.Text.Trim(),
                HeSo = heso
            };

            string result;

            if (isEditMode && int.TryParse(txtMALC.Text, out int id))
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
                if (form is frmTINHCONG tinhcongForm)
                {
                    await tinhcongForm.LoadCombosAsync();
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
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as DayTypeDto;

                if (data != null)
                {
                    txtMALC.Text = data.MaLoaiCong.ToString();
                    txtTENLC.Text = data.TenLoaiCong;
                    txtHESO.Text = data.HeSo.ToString("0.##", CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
