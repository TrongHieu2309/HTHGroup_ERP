using BLL.QL_NHAP_KHO_BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.QL_NHAP_KHO_GUI
{
    public partial class frmSANPHAM : DevExpress.XtraEditors.XtraForm
    {
        public frmSANPHAM()
        {
            InitializeComponent();
            Right_Click(this);
            txtTIMKIEM.LostFocus += txtTIMKIEM_LostFocus;
            txtTIMKIEM.Visible = false;
        }

        private void txtTIMKIEM_LostFocus(object sender, EventArgs e)
        {
            txtTIMKIEM.Visible = false;
            barbtnTIMKIEM.Enabled = false;
        }

        private void Right_Click(Control control)
        {
            control.MouseDown += Control_MouseDown;
            foreach (Control child in control.Controls)
            {
                Right_Click(child);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point mousePosition = this.PointToClient(((Control)sender).PointToScreen(new Point(e.X, e.Y)));
                contextMenuStrip1.Show(this, mousePosition);
            }
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
            txtMASP.Text = string.Empty;
            txtTENSP.Text = string.Empty;
            txtDONGIA.Text = string.Empty;
            txtMOTA.Text = string.Empty;
            comboMANCC.SelectedIndex = -1;
            comboMAMATHANG.SelectedIndex = -1;
            dateNGAYNHAP.EditValue = null;
            txtSOLUONGTON.Text = string.Empty;
            txtTRANGTHAI.Text = string.Empty;

        }

        private void frmSANPHAM_Load(object sender, EventArgs e)
        {
            SANPHAM_BLL db = new SANPHAM_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmSANPHAM_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 113;
            splitContainer1.SplitterDistance = 190;
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
                    var sanpham = view.GetRow(e.RowHandle) as SANPHAM;
                    if (sanpham != null)
                    {
                        txtMASP.Text = sanpham.MASP.ToString();
                        txtTENSP.Text = sanpham.TENSP;
                        txtDONGIA.Text = sanpham.DONGIA.ToString();
                        txtMOTA.Text = sanpham.MOTA;
                        comboMANCC.Text = sanpham.MANCC.ToString();
                        comboMAMATHANG.Text = sanpham.MAMATHANG.ToString();
                        dateNGAYNHAP.EditValue = sanpham.NGAYNHAP;
                        txtSOLUONGTON.Text = sanpham.SOLUONGTON.ToString();
                        txtTRANGTHAI.Text = sanpham.TRANGTHAI;
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtTIMKIEM.Visible = true;
            txtTIMKIEM.Focus();
            barbtnTIMKIEM.Enabled = true;
        }

        private void barbtnTIMKIEM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string timkiem = txtTIMKIEM.Text;
            if (!string.IsNullOrEmpty(timkiem))
            {
                gridView1.ApplyFindFilter(timkiem);
            }
        }
    }
}