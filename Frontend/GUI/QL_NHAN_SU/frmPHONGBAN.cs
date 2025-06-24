using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI
{
    public partial class frmPHONGBAN : DevExpress.XtraEditors.XtraForm
    {
        public frmPHONGBAN()
        {
            InitializeComponent();
        }

        private void frmPHONGBAN_Load(object sender, EventArgs e)
        {
            PHONGBAN_BLL db = new PHONGBAN_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        void _showHide(bool kt)
        {
            barbtnThem.Enabled = kt;
            barbtnSua.Enabled = !kt;
            barbtnXoa.Enabled = !kt;
            barbtnLuu.Enabled = !kt;
            barbtnHuybo.Enabled = !kt;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            groupNhap.Enabled = true;
            txtMAPB.Text = string.Empty;
            txtTENPB.Text = string.Empty;
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            barbtnHuybo.Enabled = true;
        }

        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            txtMAPB.Text = string.Empty;
            txtTENPB.Text = string.Empty;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            txtMAPB.Text = string.Empty;
            txtTENPB.Text = string.Empty;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;
            barbtnLuu.Enabled = false;
            barbtnHuybo.Enabled = false;
            groupNhap.Enabled = false;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var phongban = view.GetRow(e.RowHandle) as PHONGBAN;
                    if (phongban != null)
                    {
                        txtMAPB.Text = phongban.MAPB.ToString();
                        txtTENPB.Text = phongban.TENPB;
                    }
                }
            }
        }

        private void frmPHONGBAN_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 93;
            splitContainer2.SplitterDistance = 154;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            txtMAPB.Text = string.Empty;
            txtTENPB.Text = string.Empty;
        }
    }
}