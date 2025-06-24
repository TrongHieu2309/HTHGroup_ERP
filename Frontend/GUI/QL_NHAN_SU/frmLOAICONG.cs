using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_NHANSU
{
    public partial class frmLOAICONG : DevExpress.XtraEditors.XtraForm
    {
        public frmLOAICONG()
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
            txtMALC.Text = string.Empty;
            txtTENLC.Text = string.Empty;
            txtHESO.Text = string.Empty;
        }

        private void frmLOAICONG_Load(object sender, EventArgs e)
        {
            LOAICONG_BLL db = new LOAICONG_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmLOAICONG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 123;
            splitContainer2.SplitterDistance = 160;
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
                    var loaicong = view.GetRow(e.RowHandle) as LOAICONG;
                    if (loaicong != null)
                    {
                        txtMALC.Text = loaicong.MALC.ToString();
                        txtTENLC.Text = loaicong.TENLC;
                        txtHESO.Text = loaicong.HESO.ToString();
                    }
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}