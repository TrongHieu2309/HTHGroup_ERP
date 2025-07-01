using BLL.QL_BAN_HANG;
using BLL.QL_KHACH_HANG;
using BLL.QL_NHAN_SU;
using BLL.QL_NHAP_KHO_BLL;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_BAN_HANG
{
    public partial class frmHOADON : DevExpress.XtraEditors.XtraForm
    {
        private readonly HOADON_BLL bll = new HOADON_BLL();
        private readonly KHACHHANG_BLL khBLL = new KHACHHANG_BLL();
        private readonly SANPHAM_BLL spBLL = new SANPHAM_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();

        private bool isEditMode = false;
        private int currentChiTietId = 0;

        public frmHOADON()
        {
            InitializeComponent();
        }

        private async void frmHOADON_Load(object sender, EventArgs e)
        {
            await LoadCombosAsync();
            await LoadReceiptsAsync();
            groupNhap.Enabled = false;
            _showHide(true);

            comboMASP.SelectedIndexChanged += ComboMASP_SelectedIndexChanged;
            txtSOLUONG.TextChanged += txtSOLUONG_TextChanged_1;
            txtCHIETKHAU.TextChanged += TinhToan_TextChanged;
            txtVAT.TextChanged += TinhToan_TextChanged;

        }

        private void frmHOADON_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 244;
            splitContainer4.SplitterDistance = 140;
            splitContainer5.SplitterDistance = 100;
        }

        private async Task LoadCombosAsync()
        {
            var khDict = await khBLL.GetCustomerDictionaryAsync();
            var spList = await spBLL.GetAllAsync();
            var nvDict = await nhanSuBLL.GetEmployeeDictionaryAsync();

            comboMAKH.Properties.Items.Clear();
            comboMASP.Properties.Items.Clear();
            comboNGUOILAP.Properties.Items.Clear();


            foreach (var kv in khDict)
                comboMAKH.Properties.Items.Add($"{kv.Key}: {kv.Value}");
            foreach (var nv in nvDict)
                comboNGUOILAP.Properties.Items.Add($"{nv.Key}: {nv.Value}");
            foreach (var sp in spList)
                comboMASP.Properties.Items.Add($"{sp.MaSP}: {sp.TenSanPham}");
        }

        private async Task LoadReceiptsAsync()
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
            txtMAHD.Text = string.Empty;
            comboMAKH.SelectedIndex = -1;
            txtLOAIHD.Text = string.Empty;
            dateEditNGAYLAP.EditValue = null;
            comboNGUOILAP.SelectedIndex = -1;
            txtTONGTIEN.Text = string.Empty;
            txtTRANGTHAI.Text = string.Empty;

            txtID.Text = string.Empty;
            comboMASP.SelectedIndex = -1;
            txtSOLUONG.Text = string.Empty;
            txtDONGIA.Text = string.Empty;
            txtCHIETKHAU.Text = string.Empty;
            txtVAT.Text = string.Empty;
            txtGHICHU.Text = string.Empty;

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
            if (int.TryParse(txtMAHD.Text, out int id))
            {
                if (MessageBox.Show("Xóa hóa đơn và chi tiết?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var res = await bll.DeleteAsync(id);
                    MessageBox.Show(res);
                    await LoadReceiptsAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var maHDStr = txtMAHD.Text.Trim();
                var idCTStr = txtID.Text.Trim();

                var invariant = System.Globalization.CultureInfo.InvariantCulture;

                if (!int.TryParse(txtSOLUONG.Text, out int soluong) ||
                    !long.TryParse(txtDONGIA.Text.Replace(".", ""), out long dongia) ||
                    !long.TryParse(txtTONGTIEN.Text.Replace(".", ""), out long tongTien) ||
                    !float.TryParse(txtCHIETKHAU.Text, System.Globalization.NumberStyles.Any, invariant, out float chietkhau) ||
                    !float.TryParse(txtVAT.Text, System.Globalization.NumberStyles.Any, invariant, out float vat))
                {
                    MessageBox.Show("Lỗi!!! Không thể chuyển đổi dữ liệu. Vui lòng kiểm tra lại các giá trị nhập vào.");
                    return;
                }

                var inputPhieu = new ReceiptInputDto
                {
                    MaKH = ExtractKeyFromCombo(comboMAKH),
                    LoaiHD = txtLOAIHD.Text.Trim(),
                    NgayLap = dateEditNGAYLAP.DateTime,
                    NguoiLap = ExtractValueFromCombo(comboNGUOILAP),
                    TongTien = tongTien,
                    TrangThai = txtTRANGTHAI.Text.Trim()
                };

                var inputDetail = new ReceiptDetailInputDto
                {
                    MaSP = ExtractKeyFromCombo(comboMASP),
                    SoLuong = soluong,
                    DonGia = dongia,
                    ChietKhau = chietkhau,
                    VAT = vat,
                    GhiChu = txtGHICHU.Text
                };

                string result = "";

                bool hoaDonTonTai = int.TryParse(maHDStr, out int maHD) && (await bll.GetByIdAsync(maHD)) != null;
                bool chiTietTonTai = int.TryParse(idCTStr, out int idCT) && idCT > 0;

                if (hoaDonTonTai && chiTietTonTai)
                {
                    result = await bll.UpdateAsync(maHD, inputPhieu, idCT, inputDetail);
                }
                else
                {
                    result = await bll.CreateAsync(inputPhieu, inputDetail);
                }

                MessageBox.Show(result, "Thông báo");
                await LoadReceiptsAsync();
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
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private async void gridView1_RowClick_1(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var view = sender as GridView;
            var phieu = view.GetRow(e.RowHandle) as ReceiptDto;
            if (phieu == null) return;

            // Tạm ngắt các sự kiện tính toán
            txtSOLUONG.TextChanged -= txtSOLUONG_TextChanged_1;
            txtCHIETKHAU.TextChanged -= TinhToan_TextChanged;
            txtVAT.TextChanged -= TinhToan_TextChanged;

            // Gán dữ liệu hóa đơn
            txtMAHD.Text = phieu.MaHD.ToString();
            SetComboBoxSelectedItemByKey(comboMAKH, phieu.MaKH);
            txtLOAIHD.Text = phieu.LoaiHD;
            dateEditNGAYLAP.EditValue = phieu.NgayLap;
            SetComboBoxSelectedItemByValue(comboNGUOILAP, phieu.NguoiLap);
            txtTONGTIEN.Text = phieu.TongTien.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
            txtTRANGTHAI.Text = phieu.TrangThai;

            // Load chi tiết hóa đơn
            var details = await bll.GetDetailsByMaHDAsync(phieu.MaHD);
            gridControl2.DataSource = details;

            if (details.Count > 0)
            {
                var ct = details[0];
                txtID.Text = ct.Id.ToString();
                SetComboBoxSelectedItemByKey(comboMASP, ct.MaSP);
                txtSOLUONG.Text = ct.SoLuong.ToString();
                txtDONGIA.Text = ct.DonGia.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                txtDONGIA.Tag = ct.DonGia; // Để phục vụ tính toán chính xác về sau
                txtCHIETKHAU.Text = ct.ChietKhau.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
                txtVAT.Text = ct.VAT.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture);
                txtGHICHU.Text = ct.GhiChu;
                currentChiTietId = ct.Id;
            }

            // Gán lại sự kiện sau khi load xong dữ liệu
            txtSOLUONG.TextChanged += txtSOLUONG_TextChanged_1;
            txtCHIETKHAU.TextChanged += TinhToan_TextChanged;
            txtVAT.TextChanged += TinhToan_TextChanged;

            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnHuybo.Enabled = true;
            groupNhap.Enabled = false;
        }

        private async void ComboMASP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maSP = ExtractKeyFromCombo(comboMASP);
            if (maSP == -1) return;

            // Lấy danh sách sản phẩm từ BLL (nếu chưa có danhSachSanPham)
            var sp = await spBLL.GetByIdAsync(maSP);
            if (sp == null) return;

            txtDONGIA.Text = sp.DonGia.ToString("N0");
            txtDONGIA.Tag = sp.DonGia; // Lưu tạm để tính

            TinhToanHoaDon(); // Gọi hàm tính tổng tiền
        }

        private void TinhToanHoaDon()
        {
            if (!int.TryParse(txtSOLUONG.Text, out int soLuong)) return;

            long donGia = 0;
            if (txtDONGIA.Tag != null)
            {
                long.TryParse(txtDONGIA.Tag.ToString(), out donGia);
            }
            else
            {
                long.TryParse(txtDONGIA.Text.Replace(".", "").Replace(",", ""), out donGia);
            }

            if (donGia == 0) return;

            double chietKhau = 0, vat = 0;
            double.TryParse(txtCHIETKHAU.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out chietKhau);
            double.TryParse(txtVAT.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out vat);

            double tongTien = (soLuong * donGia) * (1 - chietKhau) * (1 + vat);
            txtTONGTIEN.Text = tongTien.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
        }

        private void TinhToan_TextChanged(object sender, EventArgs e)
        {
            TinhToanHoaDon();
        }

        private void txtSOLUONG_TextChanged_1(object sender, EventArgs e)
        {
            TinhToanHoaDon();
        }

        private void txtCHIETKHAU_TextChanged(object sender, EventArgs e)
        {
            TinhToanHoaDon();
        }

        private void txtVAT_TextChanged(object sender, EventArgs e)
        {
            TinhToanHoaDon();
        }
    }
}
