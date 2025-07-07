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
    public partial class frmLUONG : DevExpress.XtraEditors.XtraForm
    {
        private readonly LUONG_BLL db = new LUONG_BLL();
        private readonly NHANSU_BLL nhansuBLL = new NHANSU_BLL();
        private bool isEditMode = false;

        public frmLUONG()
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
            txtMALUONG.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateEditTHANG.EditValue = null;
            dateEditNAM.EditValue = null;
            txtLUONGCB.Text = string.Empty;
            txtTONG_TANGCA.Text = string.Empty;
            txtTONGPC.Text = string.Empty;
            txtTHUCLINH.Text = string.Empty;
        }

        private int ExtractKeyFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem == null) return -1;
            var parts = combo.SelectedItem.ToString().Split(':');
            return int.TryParse(parts[0], out int key) ? key : -1;
        }

        private async Task LoadComboDataAsync()
        {
            var nvDict = await nhansuBLL.GetEmployeeDictionaryAsync();
            comboMANV.Properties.Items.Clear();
            foreach (var item in nvDict)
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");
        }

        private async Task LoadGridDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
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

        private async void frmLUONG_Load(object sender, EventArgs e)
        {
            await LoadComboDataAsync();
            await LoadGridDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmLUONG_Resize(object sender, EventArgs e)
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
            if (int.TryParse(txtMALUONG.Text, out int id))
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
            if (comboMANV.SelectedItem == null ||
                dateEditTHANG.EditValue == null ||
                dateEditNAM.EditValue == null ||
                string.IsNullOrWhiteSpace(txtLUONGCB.Text) ||
                string.IsNullOrWhiteSpace(txtTONG_TANGCA.Text) ||
                string.IsNullOrWhiteSpace(txtTONGPC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            if (!decimal.TryParse(txtLUONGCB.Text, out decimal luongCB) ||
                !decimal.TryParse(txtTONG_TANGCA.Text, out decimal tongTC) ||
                !decimal.TryParse(txtTONGPC.Text, out decimal tongPC))
            {
                MessageBox.Show("Lương, tăng ca, phụ cấp không hợp lệ!", "Cảnh báo");
                return;
            }

            var thang = ((DateTime)dateEditTHANG.EditValue).Month;
            var nam = ((DateTime)dateEditNAM.EditValue).Year;
            var input = new SalaryInputDto
            {
                MaNV = ExtractKeyFromCombo(comboMANV),
                Thang = thang,
                Nam = nam,
                LuongCoBan = luongCB,
                TongTC = tongTC,
                TongPC = tongPC
            };

            string result;
            if (isEditMode && int.TryParse(txtMALUONG.Text, out int id))
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
                var data = view?.GetRow(e.RowHandle) as SalaryDto;
                if (data != null)
                {
                    txtMALUONG.Text = data.MaLuong.ToString();
                    SetComboBoxSelectedItemByKey(comboMANV, data.MaNV);
                    dateEditTHANG.EditValue = new DateTime(2024, data.Thang, 1); // placeholder year
                    dateEditNAM.EditValue = new DateTime(data.Nam, 1, 1);
                    txtLUONGCB.Text = data.LuongCoBan.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                    txtTONG_TANGCA.Text = data.TongTC.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                    txtTONGPC.Text = data.TongPC.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                    txtTHUCLINH.Text = data.ThucLinh.ToString("N0", new System.Globalization.CultureInfo("vi-VN"));
                }
            }
        }

        private async void comboMANV_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maNV = ExtractKeyFromCombo(comboMANV);
            if (maNV == -1) return;

            // 1. Lấy thông tin tăng ca của nhân viên
            var tangCaList = await new TANGCA_BLL().GetAllAsync();
            var tangCaNV = tangCaList.Where(tc => tc.MaNV == maNV).ToList();

            if (tangCaNV.Count == 0) return;

            int tongGioTangCa = tangCaNV.Sum(tc => tc.SoGio);
            int maLoaiCa = tangCaNV.First().MaLoaiCa;

            // 2. Lấy hệ số loại ca
            var loaiCa = await new LOAICA_BLL().GetByIdAsync(maLoaiCa);
            float heSoTangCa = loaiCa?.HeSoTangCa ?? 1;

            // 3. Lấy tổng phụ cấp của nhân viên
            var phuCapList = await new PHUCAP_NV_BLL().GetAllAsync();
            var pcNhanVien = phuCapList.Where(p => p.MaNV == maNV).ToList();
            decimal tongPhuCap = pcNhanVien.Sum(p => p.SoTien);

            txtTONGPC.Text = tongPhuCap.ToString("N0");

            // 4. Lưu tạm để tính sau khi nhập lương cơ bản
            txtTONGPC.Tag = tongPhuCap;
            txtTONG_TANGCA.Tag = new { tongGioTangCa, heSoTangCa };
        }

        private void txtLUONGCB_TextChanged(object sender, EventArgs e)
        {
            TinhToanLuong();
        }

        private void TinhToanLuong()
        {
            if (decimal.TryParse(txtLUONGCB.Text, out decimal luongCoBan) &&
                txtTONG_TANGCA.Tag != null &&
                txtTONGPC.Tag != null)
            {
                dynamic gioInfo = txtTONG_TANGCA.Tag;
                int tongGioTangCa = gioInfo.tongGioTangCa;
                float heSoTangCa = gioInfo.heSoTangCa;

                // Tính lương 1 giờ
                decimal luong1Gio = luongCoBan / 208;

                // Tính tổng tăng ca
                decimal tongTangCa = luong1Gio * tongGioTangCa * (decimal)heSoTangCa;
                txtTONG_TANGCA.Text = tongTangCa.ToString("N0");

                // Tính tổng phụ cấp
                decimal tongPhuCap = (decimal)txtTONGPC.Tag;

                // Tính thực lĩnh
                //decimal thucLinh = luongCoBan + tongTangCa + tongPhuCap;
                //txtTHUCLINH.Text = thucLinh.ToString("N0");
            }
        }

        private void txtLUONGCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TinhToanLuong();
                e.SuppressKeyPress = true; // Không phát tiếng beep khi nhấn Enter
            }
        }

    }
}
