using BLL.QL_NHAN_SU;
using BLL.QL_NHAP_KHO_BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmNHACUNGCAP : XtraForm
    {
        private readonly NHACUNGCAP_BLL nccService = new NHACUNGCAP_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private bool isNew = false;
        private int selectedMaNCC = -1;

        public frmNHACUNGCAP()
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
            txtMANCC.Text = string.Empty;
            txtTENNCC.Text = string.Empty;
            txtDIACHI.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEMAIL.Text = string.Empty;
            txtMOTA.Text = string.Empty;
            comboNGUOITIEPNHAN.SelectedIndex = -1;
        }

        async Task LoadData()
        {
            var data = await nccService.GetAllAsync();
            gridControl1.DataSource = data;
        }

        private string ExtractValueFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return string.Empty;

            var parts = combo.SelectedItem.ToString().Split(':');
            return parts.Length > 1 ? parts[1].Trim() : string.Empty;
        }

        private void SetComboBoxSelectedItemByValue(ComboBoxEdit comboBox, string value)
        {
            foreach (var item in comboBox.Properties.Items)
            {
                if (item is string itemStr && itemStr.Trim().EndsWith($": {value}"))
                {
                    comboBox.SelectedItem = itemStr;
                    break;
                }
            }
        }

        private async Task LoadComboNhanVienAsync()
        {
            var dict = await nhanSuBLL.GetEmployeeDictionaryAsync();

            comboNGUOITIEPNHAN.Properties.Items.Clear();

            foreach (var item in dict)
            {
                comboNGUOITIEPNHAN.Properties.Items.Add($"{item.Key}: {item.Value}");
            }
        }

        private async void frmNHACUNGCAP_Load(object sender, EventArgs e)
        {
            await LoadComboNhanVienAsync();
            await LoadData();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmNHACUNGCAP_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 160;
            splitContainer4.SplitterDistance = 122;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isNew = true;
            groupNhap.Enabled = true;
            _groupEmpty();
            _showHide(false);
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (selectedMaNCC == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa.");
                return;
            }

            isNew = false;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (selectedMaNCC == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                string msg = await nccService.DeleteAsync(selectedMaNCC);
                MessageBox.Show(msg);
                await LoadData();
                _groupEmpty();
                _showHide(true);
                selectedMaNCC = -1;
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTENNCC.Text) ||
                string.IsNullOrWhiteSpace(txtDIACHI.Text) ||
                string.IsNullOrWhiteSpace(txtSDT.Text) ||
                string.IsNullOrWhiteSpace(txtEMAIL.Text) ||
                comboNGUOITIEPNHAN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                return;
            }

            var input = new ProviderInputDto
            {
                TenNCC = txtTENNCC.Text.Trim(),
                DiaChi = txtDIACHI.Text.Trim(),
                SoDienThoai = txtSDT.Text.Trim(),
                MoTa = txtMOTA.Text?.Trim(),
                Email = txtEMAIL.Text.Trim(),
                NguoiTiepNhan = ExtractValueFromCombo(comboNGUOITIEPNHAN)
            };

            string msg;

            if (isNew)
            {
                msg = await nccService.CreateAsync(input);
            }
            else
            {
                msg = await nccService.UpdateAsync(selectedMaNCC, input);
            }

            MessageBox.Show(msg);
            await LoadData();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            isNew = false;
            selectedMaNCC = -1;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            isNew = false;
            selectedMaNCC = -1;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            groupNhap.Enabled = false;
            var view = sender as GridView;
            if (view != null && e.RowHandle >= 0)
            {
                var ncc = view.GetRow(e.RowHandle) as ProviderDto;
                if (ncc != null)
                {
                    txtMANCC.Text = ncc.MaNCC.ToString();
                    txtTENNCC.Text = ncc.TenNCC;
                    txtDIACHI.Text = ncc.DiaChi;
                    txtMOTA.Text = ncc.MoTa;
                    txtSDT.Text = ncc.SoDienThoai;
                    txtEMAIL.Text = ncc.Email;
                    SetComboBoxSelectedItemByValue(comboNGUOITIEPNHAN, ncc.NguoiTiepNhan);

                    selectedMaNCC = ncc.MaNCC;
                    barbtnSua.Enabled = true;
                    barbtnXoa.Enabled = true;
                    barbtnHuybo.Enabled = true;
                }
            }
        }
    }
}
