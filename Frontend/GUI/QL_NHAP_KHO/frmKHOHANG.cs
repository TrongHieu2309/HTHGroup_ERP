using BLL.QL_NHAP_KHO;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmKHOHANG : DevExpress.XtraEditors.XtraForm
    {
        public frmKHOHANG()
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
            txtMAKHO.Text = string.Empty;
            txtTENKHO.Text = string.Empty;
            txtDIACHI.Text = string.Empty;
            txtNGUOIQL.Text = string.Empty;
            txtGHICHU.Text = string.Empty;
        }

        private void frmKHOHANG_Load(object sender, EventArgs e)
        {
            KHOHANG_BLL db = new KHOHANG_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmKHOHANG_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 160;
            splitContainer1.SplitterDistance = 180;
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
            barbtnHuybo.Enabled = false;
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var khohang = view.GetRow(e.RowHandle) as KHOHANG;
                    if (khohang != null)
                    {
                        txtMAKHO.Text = khohang.MAKHO.ToString();
                        txtTENKHO.Text = khohang.TENKHO;
                        txtDIACHI.Text = khohang.DIACHI;
                        txtNGUOIQL.Text = khohang.NGUOIQUANLY;
                        txtGHICHU.Text = khohang.GHICHU;
                    }
                }
            }
        }
    }
}