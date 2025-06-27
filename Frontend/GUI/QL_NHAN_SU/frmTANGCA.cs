using BLL;
using BLL.QL_NHAN_SU;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTANGCA : DevExpress.XtraEditors.XtraForm
    {
        private readonly TANGCA_BLL db = new TANGCA_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private readonly LOAICA_BLL loaiCaBLL = new LOAICA_BLL();
        private bool isEditMode = false;

        public frmTANGCA()
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
            txtMATC.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            comboMALC.SelectedIndex = -1;
            dateNGAY.EditValue = null;
            txtSOGIO.Text = string.Empty;
        }

        private async Task LoadDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
        }

        public async Task LoadCombosAsync()
        {
            var nvDict = await nhanSuBLL.GetEmployeeDictionaryAsync();
            comboMANV.Properties.Items.Clear();
            foreach (var item in nvDict)
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");

            var caDict = await loaiCaBLL.GetShiftTypeDictionaryAsync();
            comboMALC.Properties.Items.Clear();
            foreach (var item in caDict)
                comboMALC.Properties.Items.Add($"{item.Key}: {item.Value}");
        }

        private int ExtractKeyFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return -1;
            var parts = combo.SelectedItem.ToString().Split(':');
            return int.TryParse(parts[0], out int key) ? key : -1;
        }

        private async void frmTANGCA_Load(object sender, EventArgs e)
        {
            await LoadCombosAsync();
            await LoadDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmTANGCA_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 160;
            splitContainer1.SplitterDistance = 180;
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
            if (int.TryParse(txtMATC.Text, out int id))
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
            if (!int.TryParse(txtSOGIO.Text, out int sogio) || sogio < 1 || sogio > 24)
            {
                MessageBox.Show("Số giờ tăng ca phải từ 1 đến 24!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var input = new ExtraShiftInputDto
            {
                Ngay = dateNGAY.DateTime,
                SoGio = sogio,
                MaNV = ExtractKeyFromCombo(comboMANV),
                MaLoaiCa = ExtractKeyFromCombo(comboMALC)
            };

            string result;

            if (isEditMode && int.TryParse(txtMATC.Text, out int id))
                result = await db.UpdateAsync(id, input);
            else
                result = await db.CreateAsync(input);

            MessageBox.Show(result, "Thông báo");
            await LoadDataAsync();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
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
            _showHide(true);
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as ExtraShiftDto;

                if (data != null)
                {
                    txtMATC.Text = data.MaTangCa.ToString();
                    dateNGAY.DateTime = data.Ngay;
                    txtSOGIO.Text = data.SoGio.ToString();
                    comboMANV.SelectedItem = $"{data.MaNV}: {data.HoTenNV}";
                    comboMALC.SelectedItem = $"{data.MaLoaiCa}: {data.CaLamViec}";
                }
            }
        }
    }
}
