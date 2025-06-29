using BLL.QL_NHAP_KHO;
using BLL.QL_NHAP_KHO_BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmNHAPKHO : XtraForm
    {
        private readonly NHAPKHO_BLL bll = new NHAPKHO_BLL();
        private readonly SANPHAM_BLL sanPhamBLL = new SANPHAM_BLL();
        private readonly NHACUNGCAP_BLL nccBll = new NHACUNGCAP_BLL();
        private readonly KHOHANG_BLL khoBLL = new KHOHANG_BLL();
        private bool isEditMode = false;
        private int currentChiTietId = 0;

        public frmNHAPKHO()
        {
            InitializeComponent();
        }

        private async void frmNHAPKHO_Load(object sender, EventArgs e)
        {
            await LoadComboBoxAsync();
            await LoadDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmNHAPKHO_Resize(object sender, EventArgs e)
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
            txtMAPHIEUNHAP.Text = string.Empty;
            dateEditNGAYNHAP.EditValue = null;
            comboMANCC.SelectedIndex = -1;
            comboMAKHO.SelectedIndex = -1;
            txtGHICHU.Text = string.Empty;

            txtID.Text = string.Empty;
            comboMASP.SelectedIndex = -1;
            txtSOLUONGNHAP.Text = string.Empty;
            txtDONGIA.Text = string.Empty;

            gridControl2.DataSource = null;
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

        private async Task LoadComboBoxAsync()
        {
            var nccDict = await nccBll.GetProviderDictionaryAsync();
            var spBLL = await sanPhamBLL.GetProductDictionaryAsync();
            var khoDict = await khoBLL.GetInventoryDictionaryAsync();

            comboMANCC.Properties.Items.Clear();
            comboMASP.Properties.Items.Clear();
            comboMAKHO.Properties.Items.Clear();

            foreach (var item in nccDict)
                comboMANCC.Properties.Items.Add($"{item.Key}: {item.Value}");

            foreach (var item in spBLL)
                comboMASP.Properties.Items.Add($"{item.Key}: {item.Value}");
            foreach (var item in khoDict)
                comboMAKHO.Properties.Items.Add($"{item.Key}: {item.Value}");
        }

        private int ExtractKeyFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem != null)
            {
                var selected = combo.SelectedItem.ToString();
                if (int.TryParse(selected.Split(':')[0], out int key))
                    return key;
            }
            return 0;
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
            if (int.TryParse(txtMAPHIEUNHAP.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập và chi tiết không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await bll.DeleteAsync(id);
                    MessageBox.Show(result);
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
                var maPhieu = txtMAPHIEUNHAP.Text.Trim();
                var idChiTiet = txtID.Text.Trim();

                var inputPhieu = new StockInInputDto
                {
                    MaNCC = ExtractKeyFromCombo(comboMANCC),
                    MaKho = ExtractKeyFromCombo(comboMAKHO),
                    NgayNhap = dateEditNGAYNHAP.DateTime,
                    GhiChu = txtGHICHU.Text
                };

                var inputChiTiet = new StockInDetailInputDto
                {
                    MaSP = ExtractKeyFromCombo(comboMASP),
                    SoLuongNhap = int.Parse(txtSOLUONGNHAP.Text),
                    DonGia = long.Parse(txtDONGIA.Text)
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
                    result = await bll.UpdateAsync(maPhieuInt, inputPhieu, idChiTietInt, inputChiTiet);
                }
                else
                {
                    // Thêm mới
                    result = await bll.CreateAsync(inputPhieu, inputChiTiet);
                }

                MessageBox.Show(result);
                await LoadDataAsync();
                _groupEmpty();
                groupNhap.Enabled = false;
                _showHide(true);
                isEditMode = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private async void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var phieu = view?.GetRow(e.RowHandle) as StockInDto;

                if (phieu != null)
                {
                    txtMAPHIEUNHAP.Text = phieu.MaPhieuNhap.ToString();
                    SetComboBoxSelectedItemByKey(comboMANCC, phieu.MaNCC);
                    SetComboBoxSelectedItemByKey(comboMAKHO, phieu.MaKho);
                    dateEditNGAYNHAP.EditValue = phieu.NgayNhap;
                    txtGHICHU.Text = phieu.GhiChu;

                    var chiTietList = await bll.GetDetailsByPhieuNhapAsync(phieu.MaPhieuNhap);
                    gridControl2.DataSource = chiTietList;

                    if (chiTietList.Any())
                    {
                        var ct = chiTietList.First();
                        txtID.Text = ct.Id.ToString();
                        SetComboBoxSelectedItemByKey(comboMASP, ct.MaSP);
                        txtSOLUONGNHAP.Text = ct.SoLuongNhap.ToString();
                        txtDONGIA.Text = ct.DonGia.ToString();
                        currentChiTietId = ct.Id;
                    }
                    else
                    {
                        txtID.Text = "";
                        comboMASP.Text = "";
                        txtSOLUONGNHAP.Text = "";
                        txtDONGIA.Text = "";
                        currentChiTietId = 0;
                    }
                }
            }
        }
    }
}
