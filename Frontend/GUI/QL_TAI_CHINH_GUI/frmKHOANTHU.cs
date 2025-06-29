using BLL.QL_TAI_CHINH_BLL;
using BLL.QL_NHAN_SU;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_TAI_CHINH_GUI
{
    public partial class frmKHOANTHU : XtraForm
    {
        private readonly KHOANTHU_BLL thuBLL = new KHOANTHU_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private bool isEditMode = false;

        public frmKHOANTHU()
        {
            InitializeComponent();
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
            txtMATHU.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateEditNGAY.EditValue = null;
            txtNOIDUNG.Text = string.Empty;
            txtSOTIEN.Text = string.Empty;
            comboBoxNGUOITHU.SelectedIndex = -1;
            txtGHICHU.Text = string.Empty;
        }

        private int ExtractKeyFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return -1;
            var parts = combo.SelectedItem.ToString().Split(':');
            return int.TryParse(parts[0], out int key) ? key : -1;
        }

        private string ExtractValueFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return string.Empty;

            var parts = combo.SelectedItem.ToString().Split(':');
            return parts.Length > 1 ? parts[1].Trim() : string.Empty;
        }

        private async Task LoadComboNhanVienAsync()
        {
            var dict = await nhanSuBLL.GetEmployeeDictionaryAsync();

            // Load comboMANV
            comboMANV.Properties.Items.Clear();
            foreach (var item in dict)
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");

            // Load comboBoxNGUOITHU
            comboBoxNGUOITHU.Properties.Items.Clear();
            foreach (var item in dict)
                comboBoxNGUOITHU.Properties.Items.Add($"{item.Key}: {item.Value}");
        }


        private async Task LoadGridDataAsync()
        {
            var list = await thuBLL.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmKHOANTHU_Load(object sender, EventArgs e)
        {
            await LoadComboNhanVienAsync();
            await LoadGridDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmKHOANTHU_Resize(object sender, EventArgs e)
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
            if (!int.TryParse(txtMATHU.Text, out int id)) return;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var result = await thuBLL.DeleteAsync(id);
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
                comboBoxNGUOITHU.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            if (!decimal.TryParse(txtSOTIEN.Text, out decimal soTien))
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo");
                return;
            }

            var input = new RevenueInputDto
            {
                MaNV = ExtractKeyFromCombo(comboMANV),
                NgayThu = Convert.ToDateTime(dateEditNGAY.EditValue),
                NoiDung = txtNOIDUNG.Text.Trim(),
                SoTien = soTien,
                NguoiThu = ExtractValueFromCombo(comboBoxNGUOITHU),
                GhiChu = txtGHICHU.Text.Trim()
            };

            string result;
            if (isEditMode && int.TryParse(txtMATHU.Text, out int id))
                result = await thuBLL.UpdateAsync(id, input);
            else
                result = await thuBLL.CreateAsync(input);

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

        private void SetComboBoxSelectedItemByValue(ComboBoxEdit comboBox, string value)
        {
            foreach (var item in comboBox.Properties.Items)
            {
                if (item is string itemStr)
                {
                    var parts = itemStr.Split(new[] { ':' }, 2);
                    if (parts.Length == 2 && parts[1].Trim().Equals(value.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        comboBox.SelectedItem = itemStr;
                        break;
                    }
                }
            }
        }


        private void SetComboBoxSelectedItemByKey(ComboBoxEdit comboBox, int key)
        {
            foreach (var item in comboBox.Properties.Items)
            {
                if (item is string itemStr && itemStr.StartsWith($"{key}:"))
                {
                    comboBox.SelectedItem = itemStr;
                    break;
                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as RevenueDto;
                if (data != null)
                {
                    txtMATHU.Text = data.MaThu.ToString();
                    SetComboBoxSelectedItemByKey(comboMANV, data.MaNV);
                    dateEditNGAY.EditValue = data.NgayThu;
                    txtNOIDUNG.Text = data.NoiDung;
                    txtSOTIEN.Text = data.SoTien.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                    SetComboBoxSelectedItemByValue(comboBoxNGUOITHU, data.NguoiThu);
                    txtGHICHU.Text = data.GhiChu;
                }
            }
        }

        private void txtSOTIEN_TextChanged(object sender, EventArgs e)
        {
            if (txtSOTIEN.Focused)
            {
                string raw = txtSOTIEN.Text.Replace(".", "");
                if (decimal.TryParse(raw, out decimal value))
                {
                    int cursor = txtSOTIEN.SelectionStart;
                    txtSOTIEN.Text = string.Format("{0:N0}", value);
                    txtSOTIEN.SelectionStart = txtSOTIEN.Text.Length;
                }
            }
        }
    }
}
