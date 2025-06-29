using BLL.QL_NHAP_KHO;
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

namespace GUI.QL_NHAP_KHO
{
    public partial class frmTONKHO : DevExpress.XtraEditors.XtraForm
    {
        private readonly TONKHO_BLL tonkhoBLL = new TONKHO_BLL();
        private readonly SANPHAM_BLL spBLL = new SANPHAM_BLL();
        private readonly KHOHANG_BLL khoBLL = new KHOHANG_BLL();
        private bool isEditMode = false;
        private Dictionary<int, string> spDict = new Dictionary<int, string>();


        public frmTONKHO()
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
            txtMATONKHO.Text = "";
            comboMASP.SelectedIndex = -1;
            txtTENSP.Text = "";
            comboMAKHO.SelectedIndex = -1;
            txtSOLUONGTON.Text = "";
            dateEditNGAYCAPNHAT.EditValue = null;
        }

        private async Task LoadDataAsync()
        {
            var list = await tonkhoBLL.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async Task LoadComboBoxAsync()
        {
            spDict = await spBLL.GetProductDictionaryAsync();
            var khoDict = await khoBLL.GetInventoryDictionaryAsync();

            comboMASP.Properties.Items.Clear();
            comboMAKHO.Properties.Items.Clear();

            foreach (var item in spDict)
                comboMASP.Properties.Items.Add($"{item.Key}: {item.Value}");

            foreach (var item in khoDict)
                comboMAKHO.Properties.Items.Add($"{item.Key}: {item.Value}");
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

        private async void frmTONKHO_Load(object sender, EventArgs e)
        {
            await LoadComboBoxAsync();
            await LoadDataAsync();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmTONKHO_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 130;
            splitContainer4.SplitterDistance = 122;
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
            if (int.TryParse(txtMATONKHO.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await tonkhoBLL.DeleteAsync(id);
                    MessageBox.Show(result);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var input = new AvailableStockInputDto
            {
                MaSP = ExtractKeyFromCombo(comboMASP),
                TenSP = txtTENSP.Text,
                MaKho = ExtractKeyFromCombo(comboMAKHO),
                SoLuongTon = int.TryParse(txtSOLUONGTON.Text, out var sl) ? sl : 0,
                NgayCapNhat = dateEditNGAYCAPNHAT.DateTime
            };

            string result;
            if (isEditMode && int.TryParse(txtMATONKHO.Text, out int id))
                result = await tonkhoBLL.UpdateAsync(id, input);
            else
                result = await tonkhoBLL.CreateAsync(input);

            MessageBox.Show(result);
            await LoadDataAsync();
            _groupEmpty();
            _showHide(true);
            groupNhap.Enabled = false;
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

        private void gridView1_RowClick_1(object sender, RowClickEventArgs e)
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
                var item = view?.GetRow(e.RowHandle) as AvailableStockDto;

                if (item != null)
                {
                    txtMATONKHO.Text = item.Id.ToString();
                    SetComboBoxSelectedItemByKey(comboMASP, item.MaSP);
                    txtTENSP.Text = item.TenSP;
                    SetComboBoxSelectedItemByKey(comboMAKHO, item.MaKho);
                    txtSOLUONGTON.Text = item.SoLuongTon.ToString();
                    dateEditNGAYCAPNHAT.EditValue = item.NgayCapNhat;
                }
            }
        }

        private void comboMASP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maSP = ExtractKeyFromCombo(comboMASP);
            if (maSP > 0 && spDict.TryGetValue(maSP, out var tenSP))
            {
                txtTENSP.Text = tenSP;
            }
        }
    }
}
