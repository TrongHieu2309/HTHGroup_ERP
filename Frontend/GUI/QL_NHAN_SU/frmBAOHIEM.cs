using BLL.QL_NHAN_SU;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBAOHIEM : DevExpress.XtraEditors.XtraForm
    {
        private readonly BAOHIEM_BLL db = new BAOHIEM_BLL();
        private readonly NHANSU_BLL nsBLL = new NHANSU_BLL();
        private bool isEditMode = false;

        public frmBAOHIEM()
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
            txtMABH.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            comboLOAIBH.SelectedIndex = -1;
            txtSOBH.Text = string.Empty;
            txtBENHVIEN.Text = string.Empty;
            dateNGAYCAP.EditValue = null;
            dateNGAYHETHAN.EditValue = null;
            txtTINHTRANG.Text = string.Empty;
        }

        public async Task LoadComboBoxNhanVienAsync()
        {
            var dict = await nsBLL.GetEmployeeDictionaryAsync();
            comboMANV.Properties.Items.Clear();
            foreach (var item in dict)
                comboMANV.Properties.Items.Add($"{item.Key}: {item.Value}");
        }

        private async Task LoadDataAsync()
        {
            var list = await db.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmBAOHIEM_Load(object sender, EventArgs e)
        {
            await LoadComboBoxNhanVienAsync();
            await LoadDataAsync();
            comboMANV.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmBAOHIEM_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 113;
            splitContainer1.SplitterDistance = 163;
            splitContainer4.SplitterDistance = 125;
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
            if (int.TryParse(txtMABH.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await db.DeleteAsync(id);
                    MessageBox.Show(result);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var input = new InsuranceInputDto
            {
                MaNV = ExtractKeyFromCombo(comboMANV.Text),
                LoaiBH = comboLOAIBH.Text,
                SoBH = txtSOBH.Text,
                BenhVien = txtBENHVIEN.Text,
                NgayCap = dateNGAYCAP.DateTime,
                NgayHetHan = dateNGAYHETHAN.DateTime,
            };

            string message;
            if (isEditMode && int.TryParse(txtMABH.Text, out int id))
                message = await db.UpdateAsync(id, input);
            else
                message = await db.CreateAsync(input);

            MessageBox.Show(message);
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
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var bh = view?.GetRow(e.RowHandle) as InsuranceDto;
                if (bh != null)
                {
                    txtMABH.Text = bh.MaBH.ToString();
                    SetComboBoxSelectedItemByKey(comboMANV, bh.MaNV);
                    comboLOAIBH.Text = bh.LoaiBH;
                    txtSOBH.Text = bh.SoBH;
                    txtBENHVIEN.Text = bh.BenhVien;
                    dateNGAYCAP.DateTime = bh.NgayCap;
                    dateNGAYHETHAN.DateTime = bh.NgayHetHan;
                    txtTINHTRANG.Text = bh.TinhTrang;
                }

                _showHide(true);
                barbtnSua.Enabled = true;
                barbtnXoa.Enabled = true;
                groupNhap.Enabled = false;
            }
        }

        private int ExtractKeyFromCombo(string comboText)
        {
            if (int.TryParse(comboText.Split(':')[0], out int key))
                return key;
            return 0;
        }
    }
}
