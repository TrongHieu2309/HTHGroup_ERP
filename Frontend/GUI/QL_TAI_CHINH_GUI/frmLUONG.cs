using BLL.QL_TAI_CHINH_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_TAI_CHINH_GUI
{
    public partial class frmLUONG : DevExpress.XtraEditors.XtraForm
    {
        public frmLUONG()
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
            txtMALUONG.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateEditTHANG.EditValue = null;
            dateEditNAM.EditValue = null;
            txtLUONGCB.Text = string.Empty;
            txtTONG_TANGCA.Text = string.Empty;
            txtTONGPC.Text = string.Empty;
            txtTHUCLINH.Text = string.Empty;
        }

        private void frmLUONG_Load(object sender, EventArgs e)
        {
            LUONG_BLL db = new LUONG_BLL();
            gridControl1.DataSource = db.GetList();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmLUONG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 168;
            splitContainer3.SplitterDistance = 160;
            splitContainer4.SplitterDistance = 180;
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
                    var luong = view.GetRow(e.RowHandle) as LUONG;
                    if (luong != null)
                    {
                        txtMALUONG.Text = luong.MALUONG.ToString();
                        comboMANV.Text = luong.MANV.ToString();
                        dateEditTHANG.EditValue = luong.THANG;
                        dateEditNAM.EditValue = luong.NAM;
                        txtLUONGCB.Text = luong.LUONGCB.ToString();
                        txtTONG_TANGCA.Text = luong.TONGTC.ToString();
                        txtTONGPC.Text = luong.TONGPC.ToString();
                        txtTHUCLINH.Text = luong.THUCLINH.ToString();
                    }
                }
            }
        }
    }
}