using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI
{
    public partial class frmBAOHIEM : DevExpress.XtraEditors.XtraForm
    {
        public frmBAOHIEM()
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
            comboMANV.SelectedIndex = -1;
            comboLOAIBH.SelectedIndex = -1;
            txtMABH.Text = string.Empty;
            txtSOBH.Text = string.Empty;
            txtBENHVIEN.Text = string.Empty;
            dateNGAYCAP.EditValue = null;
            dateNGAYHETHAN.EditValue = null;
            txtTINHTRANG.Text = string.Empty;
        }

        private void frmBAOHIEM_Load(object sender, EventArgs e)
        {
            BAOHIEM_BLL db = new BAOHIEM_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmBAOHIEM_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 113;
            splitContainer1.SplitterDistance = 163;
            splitContainer4.SplitterDistance = 125;
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
                    var baohiem = view.GetRow(e.RowHandle) as BAOHIEM;
                    if (baohiem != null)
                    {
                        txtMABH.Text = baohiem.MABH.ToString();
                        txtSOBH.Text = baohiem.SOBH;
                        txtBENHVIEN.Text = baohiem.BENHVIEN;
                        txtTINHTRANG.Text = baohiem.TINHTRANG;
                        comboMANV.EditValue = baohiem.MANV;
                        comboLOAIBH.EditValue = baohiem.LOAIBH;
                        dateNGAYCAP.EditValue = baohiem.NGAYCAP;
                        dateNGAYHETHAN.EditValue = baohiem.NGAY_HETHAN;
                    }
                }
            }
        }
    }
}