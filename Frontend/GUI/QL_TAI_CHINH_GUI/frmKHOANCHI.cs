using BLL.QL_NHAN_SU;
using BLL.QL_TAI_CHINH_BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_TAI_CHINH_GUI
{
    public partial class frmKHOANCHI : XtraForm
    {
        private readonly KHOANCHI_BLL chiBLL = new KHOANCHI_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private bool isEditMode = false;

        public frmKHOANCHI()
        {
            InitializeComponent();
        }

        private void _showHide(bool enable)
        {
            barbtnThem.Enabled = enable;
            barbtnSua.Enabled = !enable;
            barbtnXoa.Enabled = !enable;
            barbtnLuu.Enabled = !enable;
            barbtnHuybo.Enabled = !enable;
        }

        private void _groupEmpty()
        {
            txtMACHI.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateEditNGAY.EditValue = null;
            txtNOIDUNG.Text = string.Empty;
            txtSOTIEN.Text = string.Empty;
            comboNGUOICHI.SelectedIndex = -1;
            txtGHICHU.Text = string.Empty;
        }

        private int ExtractKeyFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return -1;
            var parts = combo.SelectedItem.ToString().Split(':');
            return int.TryParse(parts[0], out int key) ? key : -1;
        }

        private async Task LoadComboNhanVienAsync()
        {
            var dict = await nhanSuBLL.GetEmployeeDictionaryAsync();

            comboMANV.Properties.Items.Clear();
            comboNGUOICHI.Properties.Items.Clear();

            foreach (var item in dict)
            {
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");
                comboNGUOICHI.Properties.Items.Add(item.Value);
            }
        }

        private async Task LoadGridDataAsync()
        {
            var list = await chiBLL.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmKHOANCHI_Load(object sender, EventArgs e)
        {
            await LoadComboNhanVienAsync();
            await LoadGridDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmKHOANCHI_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 168;
            splitContainer3.SplitterDistance = 160;
            splitContainer4.SplitterDistance = 180;
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
            if (!int.TryParse(txtMACHI.Text, out int id)) return;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var result = await chiBLL.DeleteAsync(id);
                MessageBox.Show(result, "Thông báo");
                await LoadGridDataAsync();
                _groupEmpty();
                _showHide(true);
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (comboMANV.SelectedItem == null ||
                dateEditNGAY.EditValue == null ||
                string.IsNullOrWhiteSpace(txtNOIDUNG.Text) ||
                string.IsNullOrWhiteSpace(txtSOTIEN.Text) ||
                comboNGUOICHI.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            if (!decimal.TryParse(txtSOTIEN.Text, out decimal soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo");
                return;
            }

            var input = new ExpenseInputDto
            {
                MaNV = ExtractKeyFromCombo(comboMANV),
                NgayChi = Convert.ToDateTime(dateEditNGAY.EditValue),
                NoiDung = txtNOIDUNG.Text.Trim(),
                SoTien = soTien,
                NguoiChi = comboNGUOICHI.Text.Trim(),
                GhiChu = txtGHICHU.Text?.Trim()
            };

            string result;
            if (isEditMode && int.TryParse(txtMACHI.Text, out int id))
                result = await chiBLL.UpdateAsync(id, input);
            else
                result = await chiBLL.CreateAsync(input);

            MessageBox.Show(result, "Thông báo");
            await LoadGridDataAsync();
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
            Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as ExpenseDto;
                if (data != null)
                {
                    txtMACHI.Text = data.MaChi.ToString();
                    comboMANV.Text = data.MaNV.ToString(); // Có thể dùng Find nếu cần hiển thị dạng "{id}: Tên"
                    dateEditNGAY.EditValue = data.NgayChi;
                    txtNOIDUNG.Text = data.NoiDung;
                    txtSOTIEN.Text = data.SoTien.ToString("0.##");
                    comboNGUOICHI.Text = data.NguoiChi;
                    txtGHICHU.Text = data.GhiChu;
                }
            }
        }
    }
}
