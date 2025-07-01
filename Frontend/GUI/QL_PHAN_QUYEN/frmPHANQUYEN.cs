using BLL.QL_PHAN_QUYEN;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ERP.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmPHANQUYEN : DevExpress.XtraEditors.XtraForm
    {
        private readonly PHANQUYEN_BLL bll = new PHANQUYEN_BLL();
        private readonly VAITRO_BLL vaitroBLL = new VAITRO_BLL();
        private readonly QUYEN_BLL quyenBLL = new QUYEN_BLL();
        private bool isEditMode = false;
        private string selectedMaVaiTro = "";
        private int selectedMaQuyen = 0;

        public frmPHANQUYEN()
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
            comboBoxEditMAVT.SelectedIndex = -1;
            comboBoxEditMAQUYEN.SelectedIndex = -1;
            txtHANHDONG.Text = string.Empty;
        }

        private async Task LoadComboBoxesAsync()
        {
            var vaiTroList = await vaitroBLL.GetRolesDictionaryAsync();
            var quyenDict = await quyenBLL.GetAuthorisationDictionaryAsync();

            comboBoxEditMAVT.Properties.Items.Clear();
            foreach (var vt in vaiTroList)
                comboBoxEditMAVT.Properties.Items.Add($"{vt.Key}: {vt.Value}");

            comboBoxEditMAQUYEN.Properties.Items.Clear();
            foreach (var q in quyenDict)
                comboBoxEditMAQUYEN.Properties.Items.Add($"{q.Key}: {q.Value}");
        }

        private async Task LoadDataAsync()
        {
            var list = await bll.GetAllAsync();
            gridControl1.DataSource = list;
        }

        private async void frmPHANQUYEN_Load(object sender, EventArgs e)
        {
            await LoadComboBoxesAsync();
            await LoadDataAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmPHANQUYEN_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 120;
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
            if (!string.IsNullOrWhiteSpace(selectedMaVaiTro) && selectedMaQuyen > 0)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await bll.DeleteAsync(selectedMaVaiTro, selectedMaQuyen);
                    MessageBox.Show(result);
                    await LoadDataAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (comboBoxEditMAVT.SelectedIndex == -1 || comboBoxEditMAQUYEN.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Vai trò và Quyền.");
                return;
            }

            var input = new AuthoriseInputDto
            {
                MaVaiTro = ExtractKeyStringFromCombo(comboBoxEditMAVT),
                MaQuyen = ExtractKeyFromCombo(comboBoxEditMAQUYEN),
                HanhDong = txtHANHDONG.Text.Trim()
            };

            string message;

            if (isEditMode)
                message = await bll.UpdateAsync(input.MaVaiTro, input.MaQuyen, input);
            else
                message = await bll.CreateAsync(input);

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

        private string ExtractKeyStringFromCombo(ComboBoxEdit combo)
        {
            if (combo.SelectedItem != null)
            {
                var selected = combo.SelectedItem.ToString();
                var parts = selected.Split(':');
                if (parts.Length > 0)
                    return parts[0].Trim(); // Lấy phần mã (key) dạng chuỗi
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

        private void SetComboBoxSelectedItemByQuyenId(ComboBoxEdit comboBox, int maQuyen)
        {
            foreach (var item in comboBox.Properties.Items)
            {
                if (item is string str && str.StartsWith($"{maQuyen}:"))
                {
                    comboBox.SelectedItem = str;
                    break;
                }
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                var pq = view?.GetRow(e.RowHandle) as AuthoriseDto;
                if (pq != null)
                {
                    selectedMaVaiTro = pq.MaVaiTro;
                    selectedMaQuyen = pq.MaQuyen;

                    SetComboBoxSelectedItemByKey(comboBoxEditMAVT, pq.MaVaiTro);
                    SetComboBoxSelectedItemByQuyenId(comboBoxEditMAQUYEN, pq.MaQuyen);
                    txtHANHDONG.Text = pq.HanhDong;

                    _showHide(true);
                    barbtnSua.Enabled = true;
                    barbtnXoa.Enabled = true;
                    groupNhap.Enabled = false;
                }
            }
        }
    }
}
