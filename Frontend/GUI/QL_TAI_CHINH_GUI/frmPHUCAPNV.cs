using BLL.QL_TAI_CHINH_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_TAI_CHINH_GUI
{
    public partial class frmPHUCAPNV : DevExpress.XtraEditors.XtraForm
    {
        public frmPHUCAPNV()
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
            txtMAPCNV.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            comboMAPC.SelectedIndex = -1;
            dateEditTHANG.EditValue = null;
            dateEditNAM.EditValue = null;
        }

        private void frmPHUCAPNV_Load(object sender, EventArgs e)
        {
            PHUCAP_NV_BLL db = new PHUCAP_NV_BLL();
            gridControl1.DataSource = db.GetList();
            _showHide(true);
            groupNhap.Enabled = false;
        }

        private void frmPHUCAPNV_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 191;
            splitContainer2.SplitterDistance = 157;
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
                    var phucapNV = view.GetRow(e.RowHandle) as PHUCAPNV;
                    if (phucapNV != null)
                    {
                        txtMAPCNV.Text = phucapNV.MA_PCNV.ToString();
                        comboMANV.Text = phucapNV.MANV.ToString();
                        comboMAPC.Text = phucapNV.MAPC.ToString();
                        dateEditTHANG.EditValue = phucapNV.THANG;
                        dateEditNAM.EditValue = phucapNV.NAM;
                    }
                }
            }
        }
    }
}