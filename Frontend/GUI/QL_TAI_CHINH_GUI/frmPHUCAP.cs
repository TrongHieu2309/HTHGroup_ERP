using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_TAICHINH
{
    public partial class frmPHUCAP : DevExpress.XtraEditors.XtraForm
    {
        public frmPHUCAP()
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
            txtMAPC.Text = string.Empty;
            txtTENPC.Text = string.Empty;
            txtSOTIEN.Text = string.Empty;
        }

        private void frmPHUCAP_Load(object sender, EventArgs e)
        {
            PHUCAP_BLL db = new PHUCAP_BLL();
            gridControl1.DataSource = db.GetList();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmPHUCAP_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 120;
            splitContainer2.SplitterDistance = 135;
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            _groupEmpty();
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnXoa.Enabled = false;
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
            barbtnSua.Enabled = true;
            barbtnXoa.Enabled = true;

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var phucap = view.GetRow(e.RowHandle) as PHUCAP;
                    if (phucap != null)
                    {
                        txtMAPC.Text = phucap.MAPC.ToString();
                        txtTENPC.Text = phucap.TENPC;
                        txtSOTIEN.Text = phucap.SOTIEN.ToString();
                    }
                }
            }
        }
    }
}