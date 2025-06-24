using BLL.QL_NHAP_KHO_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmNHAPKHO : DevExpress.XtraEditors.XtraForm
    {
        public frmNHAPKHO()
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
            txtMAPHIEUNHAP.Text = string.Empty;
            dateEditNGAYNHAP.Text = string.Empty;
            comboMANCC.SelectedIndex = -1;
            comboMAKHO.SelectedIndex = -1;
            txtGHICHU.Text = string.Empty;

            txtID.Text = string.Empty;
            comboMAKHO.SelectedIndex = -1;
            comboMASP.SelectedIndex = -1;
            txtSOLUONGNHAP.Text = string.Empty;
            txtDONGIA.Text = string.Empty;
        }

        private NHAPKHO_BLL db = new NHAPKHO_BLL();

        private void frmNHAPKHO_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmNHAPKHO_Resize(object sender, EventArgs e)
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
                    var nhapkho = view.GetRow(e.RowHandle) as NHAPKHO;
                    if (nhapkho != null)
                    {
                        try
                        {
                            // Hiển thị dữ liệu từ NHAPKHO vào các trường tương ứng
                            txtMAPHIEUNHAP.Text = nhapkho.MAPHIEUNHAP.ToString();
                            dateEditNGAYNHAP.EditValue = nhapkho.NGAYNHAP;
                            comboMANCC.Text = nhapkho.MANCC.ToString();
                            comboMAKHO.Text = nhapkho.MAKHO.ToString();
                            txtGHICHU.Text = nhapkho.GHICHU;

                            // Lấy dữ liệu từ CHITIETNHAPHANG dựa trên MAPHIEUNHAP
                            var chiTietList = db.LayMAPHIEUNHAP(nhapkho.MAPHIEUNHAP);

                            // Hiển thị dữ liệu từ CHITIETNHAPHANG vào các trường tương ứng
                            if (chiTietList != null && chiTietList.Any())
                            {
                                var chiTiet = chiTietList.First(); // Lấy bản ghi đầu tiên, có thể điều chỉnh logic nếu cần nhiều hơn
                                txtID.Text = chiTiet.ID.ToString();
                                comboMASP.Text = chiTiet.MASP.ToString();
                                txtSOLUONGNHAP.Text = chiTiet.SOLUONGNHAP.ToString();
                                txtDONGIA.Text = chiTiet.DONGIA.ToString();
                            }
                            else
                            {
                                // Xóa dữ liệu nếu không có chi tiết nhập hàng
                                txtID.Text = string.Empty;
                                comboMASP.Text = string.Empty;
                                txtSOLUONGNHAP.Text = string.Empty;
                                txtDONGIA.Text = string.Empty;
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