using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI
{
    public partial class frmCHUCVU : DevExpress.XtraEditors.XtraForm
    {
        public frmCHUCVU()
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

        private void frmCHUCVU_Load(object sender, EventArgs e)
        {
            CHUCVU_BLL db = new CHUCVU_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void barbtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbtnLuu.Enabled = true;
            barbtnHuybo.Enabled = true;
            barbtnSua.Enabled = false;
            barbtnXoa.Enabled = false;
            groupNhap.Enabled = true;
            txtMACV.Text = string.Empty;
            txtTENCV.Text = string.Empty;
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
            txtMACV.Text = string.Empty;
            txtTENCV.Text = string.Empty;
        }

        private void barbtnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            groupNhap.Enabled = false;
            txtMACV.Text = string.Empty;
            txtTENCV.Text = string.Empty;
        }

        private void barbtnHuybo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            txtMACV.Text = string.Empty;
            txtTENCV.Text = string.Empty;
            groupNhap.Enabled = false;
        }

        private void barbtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
                    var chucvu = view.GetRow(e.RowHandle) as CHUCVU;
                    if (chucvu != null)
                    {
                        txtMACV.Text = chucvu.MACV.ToString();
                        txtTENCV.Text = chucvu.TENCV;
                    }
                }
            }
        }

        private void frmCHUCVU_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 90;
            splitContainer2.SplitterDistance = 180;
        }
    }
}