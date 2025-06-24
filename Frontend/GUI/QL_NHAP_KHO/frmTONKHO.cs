using BLL.QL_NHAP_KHO_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Linq;

namespace GUI.QL_NHAP_KHO
{
    public partial class frmTONKHO : DevExpress.XtraEditors.XtraForm
    {
        public frmTONKHO()
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
            txtMATONKHO.Text = string.Empty;
            comboMASP.SelectedIndex = -1;
            txtTENSP.Text = string.Empty;
            comboMAKHO.SelectedIndex = -1;
            txtSOLUONGTON.Text = string.Empty;
            dateEditNGAYCAPNHAT.EditValue = null;
        }

        private void frmTONKHO_Load(object sender, EventArgs e)
        {
            TONKHO_BLL db = new TONKHO_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmTONKHO_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 131;
            splitContainer1.SplitterDistance = 130;
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

        private void gridView1_RowClick_1(object sender, RowClickEventArgs e)
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
                    var tonkho = view.GetRow(e.RowHandle) as TONKHO;
                    if (tonkho != null)
                    {
                        txtMATONKHO.Text = tonkho.ID.ToString();
                        comboMASP.Text = tonkho.MASP.ToString();
                        txtTENSP.Text = tonkho.TENSP;
                        comboMAKHO.Text = tonkho.MAKHO.ToString();
                        txtSOLUONGTON.Text = tonkho.SOLUONGTON.ToString();
                        dateEditNGAYCAPNHAT.EditValue = tonkho.NGAYCAPNHAT;
                    }
                }
            }
        }
    }
}