using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI
{
    public partial class frmTANGCA : DevExpress.XtraEditors.XtraForm
    {
        public frmTANGCA()
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
            txtSOGIO.Text = string.Empty;
            comboMALC.SelectedIndex = -1;
        }

        private void frmTANGCA_Load(object sender, EventArgs e)
        {
            TANGCA_BLL db = new TANGCA_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmTANGCA_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = 160;
            splitContainer1.SplitterDistance = 180;
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
                    var tangCa = view.GetRow(e.RowHandle) as TANGCA; // Lấy đối tượng TANGCA
                    if (tangCa != null)
                    {
                        txtMATC.Text = tangCa.MA_TANGCA.ToString();
                        dateNGAY.EditValue = tangCa.NGAY;
                        txtSOGIO.Text = tangCa.SOGIO.ToString();
                        comboMALC.EditValue = tangCa.MA_LOAICA;
                        comboMANV.EditValue = tangCa.MANV;
                    }
                }
            }
        }
    }
}