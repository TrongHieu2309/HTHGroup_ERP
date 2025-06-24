using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI
{
    public partial class frmBOPHAN : DevExpress.XtraEditors.XtraForm
    {
        public frmBOPHAN()
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

        private void frmBOPHAN_Load(object sender, EventArgs e)
        {
            BOPHAN_BLL db = new BOPHAN_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
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
                    var bophan = view.GetRow(e.RowHandle) as BOPHAN;
                    if (bophan != null)
                    {
                        txtMABP.Text = bophan.MABP.ToString();
                        txtTENBP.Text = bophan.TENBP;
                    }
                }
            }
        }

        private void barbtnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupNhap.Enabled = true;
            barbtnLuu.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            barbtnHuybo.Enabled = true;
        }

        private void barbtnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            groupNhap.Enabled = true;
            txtMABP.Text = string.Empty;
            txtTENBP.Text = string.Empty;
        }

        private void barbtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            txtMABP.Text = string.Empty;
            txtTENBP.Text = string.Empty;
        }

        private void barbtnLuu_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void barbtnHuybo_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            txtMABP.Text = string.Empty;
            txtTENBP.Text = string.Empty;
        }

        private void barbtnThoat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmBOPHAN_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 166;
            splitContainer1.SplitterDistance = 90;
        }
    }
}