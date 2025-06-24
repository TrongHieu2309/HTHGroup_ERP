using BLL.QL_PHAN_QUYEN;
using DAL;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.QL_PHAN_QUYEN
{
    public partial class frmNGUOIDUNG : DevExpress.XtraEditors.XtraForm
    {
        public frmNGUOIDUNG()
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
            txtNGUOIDUNG.Text = string.Empty;
            txtMATKHAU.Text = string.Empty;
            comboBoxEditMAVT.SelectedIndex = -1;
        }

        private void frmNGUOIDUNG_Load(object sender, EventArgs e)
        {
            NGUOIDUNG_BLL db = new NGUOIDUNG_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
        }

        private void frmNGUOIDUNG_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 120;
            splitContainer2.SplitterDistance = 184;
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
                    var nguoidung = view.GetRow(e.RowHandle) as NGUOIDUNG;
                    if (nguoidung != null)
                    {
                        txtNGUOIDUNG.Text = nguoidung.TEN_ND;
                        txtMATKHAU.Text = nguoidung.MATKHAU;
                        comboBoxEditMAVT.Text = nguoidung.MAVAITRO.ToString();
                    }
                }
            }
        }

        private void barbtnTIMKIEM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string timkiem = txtTIMKIEM.Text;
            if (!string.IsNullOrEmpty(timkiem))
            {
                gridView1.ApplyFindFilter(timkiem);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            txtTIMKIEM.Visible = true;
            txtTIMKIEM.Focus();
            barbtnTIMKIEM.Enabled = true;
        }
    }
}