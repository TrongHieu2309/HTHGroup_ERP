using BLL.QL_BAN_HANG;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.QL_BAN_HANG
{
    public partial class frmXUATKHO : DevExpress.XtraEditors.XtraForm
    {
        public frmXUATKHO()
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
            txtMAPHIEUXUAT.Text = string.Empty;
            comboMAKHO.Text = string.Empty;
            txtNGUOIXUAT.Text = string.Empty;
            dateEditNGAYXUAT.EditValue = null;
            txtLYDOXUAT.Text = string.Empty;

            txtID.Text = string.Empty;
            comboMASP.Text = string.Empty;
            txtSOLUONGXUAT.Text = string.Empty;
            txtGHICHU.Text = string.Empty;
        }

        private XUATKHO_BLL db = new XUATKHO_BLL();

        private void frmXUATKHO_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmXUATKHO_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 190;
            splitContainer4.SplitterDistance = 140;
            splitContainer5.SplitterDistance = 100;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            groupNhap.Enabled = true;
            _groupEmpty();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            barbtnHuybo.Enabled = true;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            _groupEmpty();
        }

        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            _groupEmpty();
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
                    var xuatkho = view.GetRow(e.RowHandle) as XUATKHO;
                    if (xuatkho != null)
                    {
                        try
                        {
                            // Hiển thị dữ liệu từ NHAPKHO vào các trường tương ứng
                            txtMAPHIEUXUAT.Text = xuatkho.MAPHIEUXUAT.ToString();
                            comboMAKHO.Text = xuatkho.MAKHO.ToString();
                            txtNGUOIXUAT.Text = xuatkho.NGUOIXUAT;
                            dateEditNGAYXUAT.EditValue = xuatkho.NGAYXUAT;
                            txtLYDOXUAT.Text = xuatkho.LYDOXUAT;

                            // Lấy dữ liệu từ CHITIETNHAPHANG dựa trên MAPHIEUNHAP
                            var chiTietList = db.LayMAPHIEUXUAT(xuatkho.MAPHIEUXUAT);

                            // Hiển thị dữ liệu từ CHITIETNHAPHANG vào các trường tương ứng
                            if (chiTietList != null && chiTietList.Any())
                            {
                                var chiTiet = chiTietList.First(); // Lấy bản ghi đầu tiên, có thể điều chỉnh logic nếu cần nhiều hơn
                                txtID.Text = chiTiet.ID.ToString();
                                comboMASP.Text = chiTiet.MASP.ToString();
                                txtSOLUONGXUAT.Text = chiTiet.SOLUONGXUAT.ToString();
                                txtGHICHU.Text = chiTiet.GHICHU;
                            }
                            else
                            {
                                // Xóa dữ liệu nếu không có chi tiết xuất hàng
                                txtID.Text = string.Empty;
                                comboMASP.SelectedIndex = -1;
                                txtSOLUONGXUAT.Text = string.Empty;
                                txtGHICHU.Text = string.Empty;
                            }

                            // Gán dữ liệu vào gridControl2 để hiển thị chi tiết
                            gridControl2.DataSource = chiTietList;
                            gridControl2.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}