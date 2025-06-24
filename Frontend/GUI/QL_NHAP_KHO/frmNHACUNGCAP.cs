using BLL.QL_NHAP_KHO_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmNHACUNGCAP : DevExpress.XtraEditors.XtraForm
    {
        public frmNHACUNGCAP()
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
            txtMANCC.Text = string.Empty;
            txtTENNCC.Text = string.Empty;
            txtDIACHI.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEMAIL.Text = string.Empty;
            txtGHICHU.Text = string.Empty;
            txtNGUOITIEPNHAN.Text = string.Empty;

        }

        private void frmNHACUNGCAP_Load(object sender, EventArgs e)
        {
            NHACUNGCAP_BLL db = new NHACUNGCAP_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmNHACUNGCAP_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 160;
            splitContainer4.SplitterDistance = 122;
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
                    var nhacungcap = view.GetRow(e.RowHandle) as NHACUNGCAP;
                    if (nhacungcap != null)
                    {
                        txtMANCC.Text = nhacungcap.MANCC.ToString();
                        txtTENNCC.Text = nhacungcap.TENNCC;
                        txtDIACHI.Text = nhacungcap.DIACHI;
                        txtSDT.Text = nhacungcap.SODIENTHOAI;
                        txtEMAIL.Text = nhacungcap.EMAIL;
                        txtGHICHU.Text = nhacungcap.GHICHU;
                        txtNGUOITIEPNHAN.Text = nhacungcap.NGUOITIEPNHAN;
                    }
                }
            }
        }
    }
}