using BLL.QL_BAN_HANG;
using BLL.QL_KHACH_HANG;
using DAL;
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
        private readonly HOADON_BLL db = new HOADON_BLL();
        private bool isEditMode = false;

        public frmHOADON()
        {
            InitializeComponent();
        }

        private async Task LoadComboBoxMAKHAsync()
        {
            var bll = new KHACHHANG_BLL();
            var dict = await bll.GetCustomerDictionaryAsync();

            comboMAKH.Properties.Items.Clear();
            foreach (var item in dict)
            {
                comboMAKH.Properties.Items.Add($"{item.Key}: {item.Value}");
                Console.WriteLine(item.Value);
            }
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
            txtMAHD.Text = string.Empty;
            comboMAKH.SelectedIndex = -1;
            txtLOAIHD.Text = string.Empty;
            dateEditNGAYLAP.EditValue = null;
            txtNGUOILAP.Text = string.Empty;
            txtTONGTIEN.Text = string.Empty;
            txtTRANGTHAI.Text = string.Empty;

            txtID.Text = string.Empty;
            comboMASP.SelectedIndex = -1;
            txtSOLUONG.Text = string.Empty;
            txtDONGIA.Text = string.Empty;
            txtCHIETKHAU.Text = string.Empty;
            txtVAT.Text = string.Empty;
            txtGHICHU.Text = string.Empty;
        }

        private async Task LoadReceiptsAsync()
        {
            var list = await db.GetAllReceiptsAsync();
            gridControl1.DataSource = list;
        }

        private async void frmHOADON_Load(object sender, EventArgs e)
        {
            await LoadComboBoxMAKHAsync();
            groupNhap.Enabled = false;
            _showHide(true);
        }


        private void frmHOADON_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 244;
            splitContainer4.SplitterDistance = 140;
            splitContainer5.SplitterDistance = 100;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = false;
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            groupNhap.Enabled = true;
            _groupEmpty();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isEditMode = true;
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            barbtnHuybo.Enabled = true;
        }

        private async void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (int.TryParse(txtMAHD.Text, out int id))
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    var result = await db.DeleteReceiptAsync(id);
                    MessageBox.Show(result, "Thông báo");
                    await LoadReceiptsAsync();
                    _groupEmpty();
                    _showHide(true);
                }
            }
        }

        private async void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dto = new ReceiptDto
            {
                MaHD = int.TryParse(txtMAHD.Text, out int id) ? id : 0,
                MaKH = int.TryParse(comboMAKH.Text, out int makh) ? makh : 0,
                LoaiHD = txtLOAIHD.Text.Trim(),
                NgayLap = dateEditNGAYLAP.DateTime,
                NguoiLap = txtNGUOILAP.Text.Trim(),
                TongTien = long.TryParse(txtTONGTIEN.Text, out long tien) ? tien : 0,
                TrangThai = txtTRANGTHAI.Text.Trim()
            };

            string result;
            if (isEditMode && dto.MaHD > 0)
            {
                result = await db.UpdateReceiptAsync(dto.MaHD, dto);
            }
            else
            {
                result = await db.CreateReceiptAsync(dto);
            }

            MessageBox.Show(result, "Thông báo");

            await LoadReceiptsAsync();
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
            isEditMode = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick_1(object sender, RowClickEventArgs e)
        {
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var hoadon = view.GetRow(e.RowHandle) as ReceiptDto;
                    if (hoadon != null)
                    {
                        txtMAHD.Text = hoadon.MaHD.ToString();
                        comboMAKH.Text = hoadon.MaKH.ToString();
                        txtLOAIHD.Text = hoadon.LoaiHD;
                        dateEditNGAYLAP.EditValue = hoadon.NgayLap;
                        txtNGUOILAP.Text = hoadon.NguoiLap;
                        txtTONGTIEN.Text = hoadon.TongTien.ToString();
                        txtTRANGTHAI.Text = hoadon.TrangThai;
                    }
                }
            }
        }
    }
}
