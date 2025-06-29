using BLL.QL_NHAN_SU;
using BLL.QL_NHAP_KHO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmKHOHANG : DevExpress.XtraEditors.XtraForm
    {
        private KHOHANG_BLL khoService = new KHOHANG_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private bool isNew = false;
        private int selectedMaKho = -1;

        public frmKHOHANG()
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
            txtMAKHO.Text = string.Empty;
            txtTENKHO.Text = string.Empty;
            txtDIACHI.Text = string.Empty;
            comboNGUOIQL.SelectedIndex = -1;
            txtGHICHU.Text = string.Empty;
        }

        async void LoadData()
        {
            var data = await khoService.GetAllAsync();
            gridControl1.DataSource = data;
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

        private string ExtractValueFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return string.Empty;

            var parts = combo.SelectedItem.ToString().Split(':');
            return parts.Length > 1 ? parts[1].Trim() : string.Empty;
        }

        private async Task LoadComboNhanVienAsync()
        {
            var dict = await nhanSuBLL.GetEmployeeDictionaryAsync();

            comboNGUOIQL.Properties.Items.Clear();

            foreach (var item in dict)
            {
                comboNGUOIQL.Properties.Items.Add($"{item.Key}: {item.Value}");
            }
        }

        private async void frmKHOHANG_Load(object sender, EventArgs e)
        {
            await LoadComboNhanVienAsync();
            await Task.Delay(100);
            LoadData();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmKHOHANG_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 160;
            splitContainer1.SplitterDistance = 180;
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
            if (selectedMaKho == -1)
            {
                MessageBox.Show("Vui lòng chọn kho để sửa.");
                return;
            }
            isNew = false;
            groupNhap.Enabled = true;
            _showHide(false);
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (selectedMaKho == -1)
            {
                MessageBox.Show("Vui lòng chọn kho để xóa.");
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn xóa kho này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string msg = await khoService.DeleteAsync(selectedMaKho);
                MessageBox.Show(msg);
                LoadData();
                _groupEmpty();
                _showHide(true);
                selectedMaKho = -1;
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTENKHO.Text) || comboNGUOIQL.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtDIACHI.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            var input = new InventoryInputDto
            {
                TenKho = txtTENKHO.Text.Trim(),
                DiaChi = txtDIACHI.Text.Trim(),
                NguoiQuanLy = ExtractValueFromCombo(comboNGUOIQL),
                GhiChu = txtGHICHU.Text?.Trim()
            };

            string msg;
            if (isNew)
            {
                msg = await khoService.CreateAsync(input);
            }
            else
            {
                msg = await khoService.UpdateAsync(selectedMaKho, input);
            }

            MessageBox.Show(msg);
            LoadData();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            isNew = false;
            selectedMaKho = -1;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
            isNew = false;
            selectedMaKho = -1;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnHuybo.Enabled = true;

            var view = sender as GridView;
            if (view != null && e.RowHandle >= 0)
            {
                var kho = view.GetRow(e.RowHandle) as dynamic;
                if (kho != null)
                {
                    txtMAKHO.Text = kho.MaKho.ToString();
                    txtTENKHO.Text = kho.TenKho;
                    txtDIACHI.Text = kho.DiaChi;
                    SetComboBoxSelectedItemByValue(comboNGUOIQL, kho.NguoiQuanLy);
                    txtGHICHU.Text = kho.GhiChu;

                    selectedMaKho = kho.MaKho;
                }
            }
        }
    }
}
