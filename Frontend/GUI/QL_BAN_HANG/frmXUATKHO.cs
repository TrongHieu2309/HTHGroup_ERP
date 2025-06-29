using BLL.QL_BAN_HANG;
using BLL.QL_NHAN_SU;
using BLL.QL_NHAP_KHO; // nếu cần combo sản phẩm
using BLL.QL_NHAP_KHO_BLL;
using DAL;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_BAN_HANG
{
    public partial class frmXUATKHO : XtraForm
    {
        private readonly XUATKHO_BLL bll = new XUATKHO_BLL();
        private readonly KHOHANG_BLL khoBLL = new KHOHANG_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private readonly SANPHAM_BLL sanPhamBLL = new SANPHAM_BLL();

        private bool isEditMode = false;
        private int currentChiTietId = 0;

        public frmXUATKHO()
        {
            InitializeComponent();
        }

        private async void frmXUATKHO_Load(object sender, EventArgs e)
        {
            await LoadCombosAsync();
            await LoadDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmXUATKHO_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 190;
            splitContainer4.SplitterDistance = 140;
            splitContainer5.SplitterDistance = 100;
        }

        private async Task LoadDataAsync()
        {
            var list = await bll.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async Task LoadCombosAsync()
        {
            var khoDict = await khoBLL.GetInventoryDictionaryAsync();
            var nvDict = await nhanSuBLL.GetEmployeeDictionaryAsync();
            var spDict = await sanPhamBLL.GetProductDictionaryAsync();

            comboMAKHO.Properties.Items.Clear();
            comboNGUOIXUAT.Properties.Items.Clear();
            comboMASP.Properties.Items.Clear();

            foreach (var kv in khoDict)
                comboMAKHO.Properties.Items.Add($"{kv.Key}: {kv.Value}");
            foreach (var kv in nvDict)
                comboNGUOIXUAT.Properties.Items.Add($"{kv.Key}: {kv.Value}");
            foreach (var kv in spDict)
                comboMASP.Properties.Items.Add($"{kv.Key}: {kv.Value}");
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
            txtMAPHIEUXUAT.Text = "";
            comboMAKHO.SelectedIndex = -1;
            comboNGUOIXUAT.SelectedIndex = -1;
            dateEditNGAYXUAT.EditValue = null;
            txtLYDOXUAT.Text = "";

            txtID.Text = "";
            comboMASP.SelectedIndex = -1;
            txtSOLUONGXUAT.Text = "";
            txtGHICHU.Text = "";

            gridControl2.DataSource = null;
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
            if (int.TryParse(txtMAPHIEUXUAT.Text, out int id))
            {
                if (MessageBox.Show("Xóa phiếu xuất và chi tiết?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var res = await bll.DeleteAsync(id);
                    MessageBox.Show(res);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var maPhieu = txtMAPHIEUXUAT.Text.Trim();
                var idChiTiet = txtID.Text.Trim();

                var inputPhieu = new StockOutInputDto
                {
                    MaKho = ExtractKeyFromCombo(comboMAKHO),
                    NguoiXuat = ExtractValueFromCombo(comboNGUOIXUAT),
                    NgayXuat = dateEditNGAYXUAT.DateTime,
                    LyDoXuat = txtLYDOXUAT.Text
                };

                var inputDetail = new StockOutDetailInputDto
                {
                    MaSP = ExtractKeyFromCombo(comboMASP),
                    SoLuongXuat = int.Parse(txtSOLUONGXUAT.Text),
                    GhiChu = txtGHICHU.Text
                };

                string result;

                // Kiểm tra nếu MAPHIEUNHAP và ID đã tồn tại
                bool phieuTonTai = false;
                if (int.TryParse(maPhieu, out int maPhieuInt))
                    phieuTonTai = (await bll.GetByIdAsync(maPhieuInt)) != null;
                bool chiTietTonTai = int.TryParse(idChiTiet, out int idChiTietInt) && idChiTietInt > 0;

                if (phieuTonTai && chiTietTonTai)
                {
                    // Cập nhật
                    result = await bll.UpdateAsync(maPhieuInt, inputPhieu, idChiTietInt, inputDetail);
                }
                else
                {
                    // Thêm mới
                    result = await bll.CreateAsync(inputPhieu, inputDetail);
                }

                MessageBox.Show(result);
                await LoadDataAsync();
                _groupEmpty();
                groupNhap.Enabled = false;
                _showHide(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _groupEmpty();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private async void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var view = sender as GridView;
            var phieu = view.GetRow(e.RowHandle) as StockOutDto;
            if (phieu == null) return;

            txtMAPHIEUXUAT.Text = phieu.MaPhieuXuat.ToString();
            SetComboBoxSelectedItemByKey(comboMAKHO, phieu.MaKho);
            SetComboBoxSelectedItemByValue(comboNGUOIXUAT, phieu.NguoiXuat);
            dateEditNGAYXUAT.EditValue = phieu.NgayXuat;
            txtLYDOXUAT.Text = phieu.LyDoXuat;

            var details = await bll.GetDetailsByPhieuXuatAsync(phieu.MaPhieuXuat);
            gridControl2.DataSource = details;
            if (details.Count > 0)
            {
                var ct = details[0];
                txtID.Text = ct.Id.ToString();
                SetComboBoxSelectedItemByKey(comboMASP, ct.MaSP);
                txtSOLUONGXUAT.Text = ct.SoLuongXuat.ToString();
                txtGHICHU.Text = ct.GhiChu;
                currentChiTietId = ct.Id;
            }
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnHuybo.Enabled = true;
            groupNhap.Enabled = false;
        }
    }
}
