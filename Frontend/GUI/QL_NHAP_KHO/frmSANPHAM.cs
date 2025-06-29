using BLL.QL_NHAP_KHO;
using BLL.QL_NHAP_KHO_BLL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmSANPHAM : DevExpress.XtraEditors.XtraForm
    {
        private bool isEditMode = false;
        private readonly SANPHAM_BLL sanPhamBLL = new SANPHAM_BLL();
        private readonly NHACUNGCAP_BLL nccBll = new NHACUNGCAP_BLL();
        private readonly PHANLOAIMATHANG_BLL plmhBll = new PHANLOAIMATHANG_BLL();

        public frmSANPHAM()
        {
            InitializeComponent();
            Right_Click(this);
            txtTIMKIEM.LostFocus += txtTIMKIEM_LostFocus;
            txtTIMKIEM.Visible = false;
        }

        private async void frmSANPHAM_Load(object sender, EventArgs e)
        {
            await LoadComboBoxAsync();
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private async Task LoadComboBoxAsync()
        {
            var nccDict = await nccBll.GetProviderDictionaryAsync();
            var plmhDict = await plmhBll.GetProductCategoryDictionaryAsync();

            comboMANCC.Properties.Items.Clear();
            comboMMH.Properties.Items.Clear();

            foreach (var item in nccDict)
                comboMANCC.Properties.Items.Add($"{item.Key}: {item.Value}");

            foreach (var item in plmhDict)
                comboMMH.Properties.Items.Add($"{item.Key}: {item.Value}");
        }

        private async Task LoadDataAsync()
        {
            var list = await sanPhamBLL.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private void Right_Click(Control control)
        {
            control.MouseDown += Control_MouseDown;
            foreach (Control child in control.Controls)
            {
                Right_Click(child);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePosition = this.PointToClient(((Control)sender).PointToScreen(new Point(e.X, e.Y)));
                contextMenuStrip1.Show(this, mousePosition);
            }
        }

        private void txtTIMKIEM_LostFocus(object sender, EventArgs e)
        {
            txtTIMKIEM.Visible = false;
            barbtnTIMKIEM.Enabled = false;
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
            txtMASP.Text = string.Empty;
            txtTENSP.Text = string.Empty;
            txtDONGIA.Text = string.Empty;
            txtMOTA.Text = string.Empty;
            comboMANCC.SelectedIndex = -1;
            comboMMH.SelectedIndex = -1;
            dateNGAYNHAP.EditValue = null;
            txtSOLUONGTON.Text = string.Empty;
            txtTRANGTHAI.Text = string.Empty;
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
            if (int.TryParse(txtMASP.Text, out int id))
            {
                var confirm = MessageBox.Show("Xác nhận xóa?", "Thông báo", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await sanPhamBLL.DeleteAsync(id);
                    MessageBox.Show(result);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var input = new ProductInputDto
            {
                TenSanPham = txtTENSP.Text,
                MoTa = txtMOTA.Text,
                DonGia = long.TryParse(txtDONGIA.Text, out var gia) ? gia : 0,
                SoLuongTon = int.TryParse(txtSOLUONGTON.Text, out var sl) ? sl : 0,
                NgayNhap = dateNGAYNHAP.DateTime,
                TrangThai = txtTRANGTHAI.Text,
                MaNCC = ExtractKeyFromCombo(comboMANCC),
                MaMatHang = ExtractKeyFromCombo(comboMMH)
            };

            string message;
            if (isEditMode && int.TryParse(txtMASP.Text, out int id))
                message = await sanPhamBLL.UpdateAsync(id, input);
            else
                message = await sanPhamBLL.CreateAsync(input);

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
                var sp = view?.GetRow(e.RowHandle) as ProductDto;
                if (sp != null)
                {
                    txtMASP.Text = sp.MaSP.ToString();
                    txtTENSP.Text = sp.TenSanPham;
                    txtMOTA.Text = sp.MoTa;
                    txtDONGIA.Text = sp.DonGia.ToString();
                    txtSOLUONGTON.Text = sp.SoLuongTon.ToString();
                    txtTRANGTHAI.Text = sp.TrangThai;
                    dateNGAYNHAP.DateTime = sp.NgayNhap;
                    SetComboBoxSelectedItemByKey(comboMANCC, sp.MaNCC);
                    SetComboBoxSelectedItemByKey(comboMMH, sp.MaMatHang);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void frmSANPHAM_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 113;
            splitContainer1.SplitterDistance = 190;
            splitContainer4.SplitterDistance = 125;
        }
    }
}
