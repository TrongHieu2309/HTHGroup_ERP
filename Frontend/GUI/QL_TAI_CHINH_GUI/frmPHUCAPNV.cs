using BLL;
using BLL.QL_NHAN_SU;
using BLL.QL_TAI_CHINH_BLL;
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
    public partial class frmPHUCAPNV : DevExpress.XtraEditors.XtraForm
    {
        private readonly PHUCAP_NV_BLL db = new PHUCAP_NV_BLL();
        private readonly NHANSU_BLL nhansuBLL = new NHANSU_BLL();
        private readonly PHUCAP_BLL phucapBLL = new PHUCAP_BLL();
        private bool isEditMode = false;

        public frmPHUCAPNV()
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
            txtMAPCNV.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            comboMAPC.SelectedIndex = -1;
            dateEditTHANG.EditValue = null;
            dateEditNAM.EditValue = null;
            txtSoTien.Text = string.Empty;
        }

        private int ExtractKeyFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return -1;
            var parts = combo.SelectedItem.ToString().Split(':');
            return int.TryParse(parts[0], out int key) ? key : -1;
        }

        public async Task LoadComboDataAsync()
        {
            var nvDict = await nhansuBLL.GetEmployeeDictionaryAsync();
            comboMANV.Properties.Items.Clear();
            foreach (var item in nvDict)
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");

            var pcList = await phucapBLL.GetAllAsync();
            comboMAPC.Properties.Items.Clear();
            foreach (var pc in pcList)
                comboMAPC.Properties.Items.Add($"{pc.MaPC}: {pc.TenPhuCap}");
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

        private async Task LoadGridDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmPHUCAPNV_Load(object sender, EventArgs e)
        {
            await LoadComboDataAsync();
            await LoadGridDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmPHUCAPNV_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 210;
            splitContainer2.SplitterDistance = 157;
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
            if (int.TryParse(txtMAPCNV.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await db.DeleteAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadGridDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (comboMANV.SelectedItem == null || comboMAPC.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            if (!decimal.TryParse(txtSoTien.Text, out decimal soTien) || soTien < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo");
                return;
            }

            var thang = ((DateTime)dateEditTHANG.EditValue).Month;
            var nam = ((DateTime)dateEditNAM.EditValue).Year;

            var input = new EmployeeAllowanceInputDto
            {
                MaNV = ExtractKeyFromCombo(comboMANV),
                MaPC = ExtractKeyFromCombo(comboMAPC),
                Thang = thang,
                Nam = nam,
                SoTien = soTien
            };

            string result;
            if (isEditMode && int.TryParse(txtMAPCNV.Text, out int id))
                result = await db.UpdateAsync(id, input);
            else
                result = await db.CreateAsync(input);

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
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as EmployeeAllowanceDto;
                if (data != null)
                {
                    txtMAPCNV.Text = data.MaPhuCapNV.ToString();
                    SetComboBoxSelectedItemByKey(comboMANV, data.MaNV);
                    SetComboBoxSelectedItemByKey(comboMAPC, data.MaPC);
                    dateEditTHANG.EditValue = new DateTime(2025, data.Thang, 1);
                    dateEditNAM.EditValue = new DateTime(data.Nam, 1, 1);
                    txtSoTien.Text = data.SoTien.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                }
            }
        }

        private async void comboMAPC_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            if (comboMAPC.SelectedItem == null)
            {
                txtSoTien.Text = string.Empty;
                return;
            }

            int maPC = ExtractKeyFromCombo(comboMAPC);
            if (maPC < 0) return;

            var selected = await phucapBLL.GetByIdAsync(maPC);
            if (selected != null)
                txtSoTien.Text = selected.SoTien.ToString("N0");
        }
    }
}
