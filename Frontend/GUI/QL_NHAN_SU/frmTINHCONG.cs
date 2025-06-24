using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_NHANSU
{
    public partial class frmTINHCONG : DevExpress.XtraEditors.XtraForm
    {
        public frmTINHCONG()
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
            txtMATC.Text = string.Empty;
            comboMANV.SelectedIndex = -1;
            dateNGAY.EditValue = null;
            timeEditGIORA.EditValue = null;
            timeEditGIOVAO.EditValue = null;
            comboMALC.SelectedIndex = -1;
        }

        private void frmTINHCONG_Load(object sender, EventArgs e)
        {
            TINHCONG_BLL db = new TINHCONG_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmTINHCONG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 200;
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
                    var tinhcong = view.GetRow(e.RowHandle) as TINHCONG;
                    if (tinhcong != null)
                    {
                        txtMATC.Text = tinhcong.MATC.ToString();
                        dateNGAY.EditValue = tinhcong.NGAY;
                        timeEditGIOVAO.EditValue = tinhcong.GIOVAO;
                        timeEditGIORA.EditValue = tinhcong.GIORA;
                        comboMANV.EditValue = tinhcong.MANV;
                        comboMALC.EditValue = tinhcong.MALC;
                    }
                }
            }
        }
    }
}