using BLL.QL_NHAN_SU;
using BLL.QL_TRINH_DO;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using GUI.QL_NHANSU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNHANSU : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();

        public frmNHANSU()
        {
            InitializeComponent();
        }

        //private async Task LoadComboBoxDepartmentAsync()
        //{
        //    var bll = new PHONGBAN_BLL();
        //    var dict = await bll.GetDepartmentDictionaryAsync();

        //    comboPHONGBAN.Properties.Items.Clear();
        //    foreach (var item in dict)
        //    {
        //        comboPHONGBAN.Properties.Items.Add($"{item.Key}: {item.Value}");
        //    }
        //}

        //private async Task LoadComboBoxSectionAsync()
        //{
        //    var bll = new BOPHAN_BLL();
        //    var dict = await bll.GetSectionDictionaryAsync();

        //    comboPHONGBAN.Properties.Items.Clear();
        //    foreach (var item in dict)
        //    {
        //        comboPHONGBAN.Properties.Items.Add($"{item.Key}: {item.Value}");
        //    }
        //}

        //private async Task LoadComboBoxJobTitleAsync()
        //{
        //    var bll = new CHUCVU_BLL();
        //    var dict = await bll.GetJobTitleDictionaryAsync();

        //    comboPHONGBAN.Properties.Items.Clear();
        //    foreach (var item in dict)
        //    {
        //        comboPHONGBAN.Properties.Items.Add($"{item.Key}: {item.Value}");
        //    }
        //}

        //private async Task LoadComboBoxEducationLevelAsync()
        //{
        //    var bll = new TRINHDO_BLL();
        //    var dict = await bll.GetDictionaryAsync();

        //    comboPHONGBAN.Properties.Items.Clear();
        //    foreach (var item in dict)
        //    {
        //        comboPHONGBAN.Properties.Items.Add($"{item.Key}: {item.Value}");
        //    }
        //}

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
            txtMANV.Text = "";
            txtHOTEN.Text = "";
            txtEMAIL.Text = "";
            txtSDT.Text = "";
            txtCCCD.Text = "";
            txtDIACHI.Text = "";
            comboGIOITINH.SelectedIndex = -1;
            dateNGAYSINH.EditValue = null;
            comboPHONGBAN.SelectedIndex = -1;
            comboBOPHAN.SelectedIndex = -1;
            comboCHUCVU.SelectedIndex = -1;
            comboTRINHDO.SelectedIndex = -1;
        }

        public async Task LoadComboBoxAsync()
        {
            var pb = new PHONGBAN_BLL();
            var bp = new BOPHAN_BLL();
            var cv = new CHUCVU_BLL();
            var td = new TRINHDO_BLL();

            var phongbanDict = await pb.GetDepartmentDictionaryAsync();
            var bophanDict = await bp.GetSectionDictionaryAsync();
            var chucvuDict = await cv.GetJobTitleDictionaryAsync();
            var trinhdoDict = await td.GetDictionaryAsync();

            comboPHONGBAN.Properties.Items.Clear();
            comboBOPHAN.Properties.Items.Clear();
            comboCHUCVU.Properties.Items.Clear();
            comboTRINHDO.Properties.Items.Clear();

            foreach (var item in phongbanDict)
                comboPHONGBAN.Properties.Items.Add($"{item.Key}: {item.Value}");

            foreach (var item in bophanDict)
                comboBOPHAN.Properties.Items.Add($"{item.Key}: {item.Value}");

            foreach (var item in chucvuDict)
                comboCHUCVU.Properties.Items.Add($"{item.Key}: {item.Value}");

            foreach (var item in trinhdoDict)
                comboTRINHDO.Properties.Items.Add($"{item.Key}: {item.Value}");
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

        private async Task LoadDataAsync()
        {
            var list = await nhanSuBLL.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmNHANSU_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
            await LoadComboBoxAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmNHANSU_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 170;
            splitContainer1.SplitterDistance = 212;
            splitContainer4.SplitterDistance = 170;
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
            if (int.TryParse(txtMANV.Text, out int maNV))
            {
                var confirm = MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await nhanSuBLL.DeleteAsync(maNV);
                    MessageBox.Show(result);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var input = new EmployeeInputDto
            {
                HoTen = txtHOTEN.Text,
                NgaySinh = dateNGAYSINH.DateTime,
                GioiTinh = comboGIOITINH.Text,
                SoDienThoai = txtSDT.Text,
                CCCD = txtCCCD.Text,
                Email = txtEMAIL.Text,
                DiaChi = txtDIACHI.Text,
                MaPhongBan = ExtractKeyFromCombo(comboPHONGBAN),
                MaBoPhan = ExtractKeyFromCombo(comboBOPHAN),
                MaChucVu = ExtractKeyFromCombo(comboCHUCVU),
                MaTDHV = ExtractKeyFromCombo(comboTRINHDO)
            };

            string message;
            if (isEditMode && int.TryParse(txtMANV.Text, out int id))
                message = await nhanSuBLL.UpdateAsync(id, input);
            else
                message = await nhanSuBLL.CreateAsync(input);

            MessageBox.Show(message);

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmBAOHIEM baohiemForm)
                {
                    await baohiemForm.LoadComboBoxNhanVienAsync();
                    break;
                }
            }

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmTANGCA tangcaForm)
                {
                    await tangcaForm.LoadCombosAsync();
                    break;
                }
            }

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmTINHCONG tinhcongForm)
                {
                    await tinhcongForm.LoadCombosAsync();
                    break;
                }
            }

            await LoadDataAsync();
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
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
            _showHide(true);
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var ns = view?.GetRow(e.RowHandle) as EmployeeDto;

                if (ns != null)
                {
                    txtMANV.Text = ns.MaNV.ToString();
                    txtHOTEN.Text = ns.HoTen;
                    txtEMAIL.Text = ns.Email;
                    txtSDT.Text = ns.SoDienThoai;
                    txtCCCD.Text = ns.CCCD;
                    txtDIACHI.Text = ns.DiaChi;
                    dateNGAYSINH.DateTime = ns.NgaySinh;
                    comboGIOITINH.Text = ns.GioiTinh;

                    SetComboBoxSelectedItemByKey(comboPHONGBAN, ns.MaPhongBan);
                    SetComboBoxSelectedItemByKey(comboBOPHAN, ns.MaBoPhan);
                    SetComboBoxSelectedItemByKey(comboCHUCVU, ns.MaChucVu);
                    SetComboBoxSelectedItemByKey(comboTRINHDO, ns.MaTDHV);
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            txtTIMKIEM.Visible = true;
            txtTIMKIEM.Focus();
            barbtnTIMKIEM.Enabled = true;
        }

        private void barbtnTIMKIEM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string timkiem = txtTIMKIEM.Text;
            if (!string.IsNullOrEmpty(timkiem))
            {
                gridView1.ApplyFindFilter(timkiem);
            }
        }
    }
}
