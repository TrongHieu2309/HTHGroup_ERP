using BLL;
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing;

namespace GUI
{
    public partial class frmNHANSU : DevExpress.XtraEditors.XtraForm
    {
        public frmNHANSU()
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

        private void frmNHANSU_Resize(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 170;
            splitContainer1.SplitterDistance = 212;
            splitContainer4.SplitterDistance = 170;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

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
            txtMANV.Text = string.Empty;
            txtHOTEN.Text = string.Empty;
            txtDIACHI.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEMAIL.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            dateNGAYSINH.EditValue = null;
            comboGIOITINH.SelectedIndex = -1;
            comboTRINHDO.SelectedIndex = -1;
            comboPHONGBAN.SelectedIndex = -1;
            comboBOPHAN.SelectedIndex = -1;
            comboCHUCVU.SelectedIndex = -1;
        }

        private void frmNHANSU_Load(object sender, EventArgs e)
        {
            NHANSU_BLL db = new NHANSU_BLL();
            gridControl1.DataSource = db.GetList();
            groupNhap.Enabled = false;
            _showHide(true);
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
            _groupEmpty();

            if (e.RowHandle >= 0)
            {
                var view = sender as GridView;
                if (view != null)
                {
                    var nhanSu = view.GetRow(e.RowHandle) as NHANSU;
                    if (nhanSu != null)
                    {
                        txtMANV.Text = nhanSu.MANV.ToString();
                        txtHOTEN.Text = nhanSu.HOTEN;
                        dateNGAYSINH.EditValue = nhanSu.NGAYSINH;
                        comboGIOITINH.EditValue = nhanSu.GIOITINH;
                        txtSDT.Text = nhanSu.SDT;
                        txtCCCD.Text = nhanSu.CCCD;
                        txtEMAIL.Text = nhanSu.EMAIL;
                        txtDIACHI.Text = nhanSu.DIACHI;
                        comboPHONGBAN.EditValue = nhanSu.MAPB;
                        comboBOPHAN.EditValue = nhanSu.MABP;
                        comboCHUCVU.EditValue = nhanSu.MACV;
                        comboTRINHDO.EditValue = nhanSu.MATD;
                    }
                }
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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