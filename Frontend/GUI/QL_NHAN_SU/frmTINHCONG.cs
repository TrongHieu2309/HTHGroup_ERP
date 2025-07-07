using BLL;
using BLL.QL_NHAN_SU;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHANSU
{
    public partial class frmTINHCONG : DevExpress.XtraEditors.XtraForm
    {
        private readonly TINHCONG_BLL db = new TINHCONG_BLL();
        private readonly LOAICONG_BLL loaicongBLL = new LOAICONG_BLL();
        private readonly NHANSU_BLL nhanSuBLL = new NHANSU_BLL();
        private bool isEditMode = false;

        public frmTINHCONG()
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
            txtMATC.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateNGAY.EditValue = null;
            timeEditGIOVAO.EditValue = null;
            timeEditGIORA.EditValue = null;
            comboMALC.SelectedIndex = -1;
        }

        private void ConfigureTimeEdit()
        {
            timeEditGIOVAO.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEditGIOVAO.Properties.DisplayFormat.FormatString = "HH:mm";
            timeEditGIOVAO.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEditGIOVAO.Properties.EditFormat.FormatString = "HH:mm";
            timeEditGIOVAO.Properties.Mask.EditMask = "HH:mm";

            timeEditGIORA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEditGIORA.Properties.DisplayFormat.FormatString = "HH:mm";
            timeEditGIORA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            timeEditGIORA.Properties.EditFormat.FormatString = "HH:mm";
            timeEditGIORA.Properties.Mask.EditMask = "HH:mm";
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

        private async Task LoadDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
        }

        public async Task LoadCombosAsync()
        {
            var nvDict = await nhanSuBLL.GetEmployeeDictionaryAsync();
            comboMANV.Properties.Items.Clear();
            foreach (var item in nvDict)
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");

            var caDict = await loaicongBLL.GetDayTypeDictionaryAsync();
            comboMALC.Properties.Items.Clear();
            foreach (var item in caDict)
                comboMALC.Properties.Items.Add($"{item.Key}: {item.Value}");
        }

        private async void frmTINHCONG_Load(object sender, EventArgs e)
        {
            ConfigureTimeEdit();
            await LoadCombosAsync();
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmTINHCONG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 200;
            splitContainer2.SplitterDistance = 160;
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
            if (int.TryParse(txtMATC.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await db.DeleteAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (comboMANV.EditValue == null || comboMALC.EditValue == null || dateNGAY.EditValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                return;
            }

            var input = new WorkRecordInputDto
            {
                MaNhanVien = ExtractKeyFromCombo(comboMANV),
                MaLoaiCong = ExtractKeyFromCombo(comboMALC),
                Ngay = dateNGAY.DateTime,
                GioVao = ((DateTime)timeEditGIOVAO.EditValue).TimeOfDay,
                GioRa = ((DateTime)timeEditGIORA.EditValue).TimeOfDay
            };

            string result;

            if (isEditMode && int.TryParse(txtMATC.Text, out int id))
            {
                result = await db.UpdateAsync(id, input);
            }
            else
            {
                result = await db.CreateAsync(input);
            }

            MessageBox.Show(result, "Thông báo");
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
            isEditMode = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var data = view?.GetRow(e.RowHandle) as WorkRecordDto;
                if (data != null)
                {
                    txtMATC.Text = data.MaTinhCong.ToString();
                    dateNGAY.EditValue = data.Ngay;
                    timeEditGIOVAO.EditValue = DateTime.Today.Add(data.GioVao);
                    timeEditGIORA.EditValue = DateTime.Today.Add(data.GioRa);
                    SetComboBoxSelectedItemByKey(comboMANV, data.MaNhanVien);
                    SetComboBoxSelectedItemByKey(comboMALC, data.MaLoaiCong);
                }
            }
        }
    }
}
