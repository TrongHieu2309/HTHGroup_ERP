using BLL.QL_PHAN_QUYEN;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_PHAN_QUYEN
{
    public partial class frmNGUOIDUNG : DevExpress.XtraEditors.XtraForm
    {
        private readonly NGUOIDUNG_BLL bll = new NGUOIDUNG_BLL();
        private readonly VAITRO_BLL vaiTroBLL = new VAITRO_BLL();
        private bool isEditMode = false;
        private int selectedId = 0;

        public frmNGUOIDUNG()
        {
            InitializeComponent();
            Right_Click(this);
            txtTIMKIEM.LostFocus += txtTIMKIEM_LostFocus;
            txtTIMKIEM.Visible = false;
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
            txtNGUOIDUNG.Text = string.Empty;
            txtMATKHAU.Text = string.Empty;
            comboBoxEditMAVT.SelectedIndex = -1;
        }

        private async Task LoadVaiTroAsync()
        {
            var vaiTros = await vaiTroBLL.GetRolesDictionaryAsync();
            comboBoxEditMAVT.Properties.Items.Clear();
            foreach (var item in vaiTros)
            {
                comboBoxEditMAVT.Properties.Items.Add($"{item.Key}: {item.Value}");
            }
        }

        private async Task LoadDataAsync()
        {
            var list = await bll.GetAllAsync();
            gridControl1.DataSource = list;

            foreach (var user in list)
            {
                Console.WriteLine($"User: {user.TenDangNhap}, Pass: {user.MatKhau}");
            }
        }

        private async void frmNGUOIDUNG_Load(object sender, EventArgs e)
        {
            await LoadVaiTroAsync();
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmNGUOIDUNG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 155;
            splitContainer2.SplitterDistance = 184;
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
            if (selectedId > 0)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await bll.DeleteAsync(selectedId);
                    MessageBox.Show(result);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string result;

            if (isEditMode && int.TryParse(txtMANGUOIDUNG.Text, out int id))
            {
                var updateDto = new UserUpdateDto
                {
                    TenDangNhap = txtNGUOIDUNG.Text.Trim(),
                    MatKhau = txtMATKHAU.Text.Trim(),
                    MaVaiTro = ExtractKeyStringFromCombo(comboBoxEditMAVT)
                };

                result = await bll.UpdateAsync(id, updateDto);
            }
            else
            {
                var registerDto = new UserRegisterDto
                {
                    TenDangNhap = txtNGUOIDUNG.Text.Trim(),
                    MatKhau = txtMATKHAU.Text.Trim(),
                    MaVaiTro = ExtractKeyStringFromCombo(comboBoxEditMAVT)
                };

                result = await bll.CreateAsync(registerDto);
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
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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

        private void txtTIMKIEM_LostFocus(object sender, EventArgs e)
        {
            txtTIMKIEM.Visible = false;
            barbtnTIMKIEM.Enabled = false;
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

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var user = view?.GetRow(e.RowHandle) as UserDto;

                if (user != null)
                {
                    txtMANGUOIDUNG.Text = user.Id.ToString();
                    txtNGUOIDUNG.Text = user.TenDangNhap;
                    txtMATKHAU.Text = user.MatKhau;
                    SetComboBoxSelectedItemByKey(comboBoxEditMAVT, user.MaVaiTro);

                    _showHide(true);
                    barbtnSua.Enabled = true;
                    barbtnXoa.Enabled = true;
                    groupNhap.Enabled = false;
                }
            }
        }

        private string ExtractKeyStringFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem != null)
            {
                var selected = combo.SelectedItem.ToString();
                var parts = selected.Split(':');
                if (parts.Length > 0)
                    return parts[0].Trim();
            }
            return string.Empty;
        }

        private void SetComboBoxSelectedItemByKey(ComboBoxEdit comboBox, string key)
        {
            foreach (var item in comboBox.Properties.Items)
            {
                if (item is string str && str.StartsWith(key))
                {
                    comboBox.SelectedItem = str;
                    break;
                }
            }
        }
    }
}
