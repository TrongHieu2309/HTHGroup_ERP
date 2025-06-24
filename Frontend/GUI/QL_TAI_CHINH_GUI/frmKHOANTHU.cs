using BLL.QL_TAI_CHINH_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_TAI_CHINH_GUI
{
    public partial class frmKHOANTHU : DevExpress.XtraEditors.XtraForm
    {
        public frmKHOANTHU()
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
            txtMATHU.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateEditNGAY.EditValue = null;
            txtNOIDUNG.Text = string.Empty;
            txtSOTIEN.Text = string.Empty;
            txtNGUOITHU.Text = string.Empty;
            txtGHICHU.Text = string.Empty;
        }

        private void frmKHOANTHU_Load(object sender, EventArgs e)
        {
            KHOANTHU_BLL db = new KHOANTHU_BLL();
            gridControl1.DataSource = db.GetList();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmKHOANTHU_Resize(object sender, EventArgs e)
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
                    var thu = view.GetRow(e.RowHandle) as THU;
                    if (thu != null)
                    {
                        txtMATHU.Text = thu.MATHU.ToString();
                        comboMANV.Text = thu.MANV.ToString();
                        dateEditNGAY.EditValue = thu.NGAYTHU;
                        txtNOIDUNG.Text = thu.NOIDUNG;
                        txtSOTIEN.Text = thu.SOTIEN.ToString();
                        txtNGUOITHU.Text = thu.NGUOITHU;
                        txtGHICHU.Text = thu.GHICHU;
                    }
                }
            }
        }
    }
}