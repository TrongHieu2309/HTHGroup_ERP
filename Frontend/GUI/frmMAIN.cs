using GUI.QL_BAN_HANG;
using GUI.QL_NHANSU;
using GUI.QL_NHAP_KHO;
using GUI.QL_NHAP_KHO_GUI;
using GUI.QL_TAICHINH;
using GUI.QL_TAI_CHINH_GUI;
using System;
using System.Windows.Forms;
using GUI.QL_KHACH_HANG;
using GUI.QL_PHAN_QUYEN;
using GUI.QuyTrinhHoatDong;

namespace GUI
{
    public partial class frmMAIN : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMAIN()
        {
            InitializeComponent();

        }

        void OpenForm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTRINHDO));
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPHONGBAN));
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmBOPHAN));
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmCHUCVU));
        }

        private void barbtnTTNS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNHANSU));
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmBAOHIEM));
        }

        /*Bảng tăng ca*/
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTANGCA));
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLOAICA));
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTINHCONG));
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLOAICONG));
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPHUCAP));
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPHUCAPNV));
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLUONG));
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKHOANTHU));
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKHOANCHI));
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKHOHANG));
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmSANPHAM));
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNHACUNGCAP));
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNHAPKHO));
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmXUATKHO));
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTONKHO));
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmHOADON));
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKHACHHANG));
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            barSubQUYTRINH.Enabled = true;
            if (comboBoxEdit1.SelectedItem.ToString() == "Phân hệ nhân sự")
            {
                this.BackgroundImage = Properties.Resources.HR_plan;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                barbtnNHANSU.Enabled = true;
                barbtnTAICHINH.Enabled = true;
                barbtnBANHANG.Enabled = false;
                barbtnNHAPHANG.Enabled = false;
                foreach (var doc in documentManager1.View.Documents.ToArray())
                {
                    doc.Form.Close();
                }
                ribbonPage3.Visible = false;
                ribbonPage4.Visible = false;
                ribbonPage5.Visible = false;
                ribbonPage6.Visible = false;
                ribbonPage1.Visible = true;
                ribbonPage2.Visible = true;
            }
            else if (comboBoxEdit1.SelectedItem.ToString() == "Phân hệ bán lẻ")
            {
                this.BackgroundImage = Properties.Resources.sale4;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                barbtnBANHANG.Enabled = true;
                barbtnNHAPHANG.Enabled = true;
                barbtnNHANSU.Enabled = false;
                barbtnTAICHINH.Enabled = false;
                foreach (var doc in documentManager1.View.Documents.ToArray())
                {
                    doc.Form.Close();
                }
                ribbonPage1.Visible = false;
                ribbonPage2.Visible = false;
                ribbonPage6.Visible = false;
                ribbonPage3.Visible = true;
                ribbonPage4.Visible = true;
                ribbonPage5.Visible = true;
            }
            else if (comboBoxEdit1.SelectedItem.ToString() == "Phân quyền")
            {
                this.BackgroundImage = Properties.Resources.quyen;
                this.BackgroundImageLayout = ImageLayout.Tile;
                barbtnBANHANG.Enabled = false;
                barbtnNHAPHANG.Enabled = false;
                barbtnNHANSU.Enabled = false;
                barbtnTAICHINH.Enabled = false;
                foreach (var doc in documentManager1.View.Documents.ToArray())
                {
                    doc.Form.Close();
                }
                ribbonPage1.Visible = false;
                ribbonPage2.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage4.Visible = false;
                ribbonPage5.Visible = false;
                ribbonPage6.Visible = true;
            }
            else
            {
                ribbonPage1.Visible = false;
                ribbonPage2.Visible = false;
                ribbonPage3.Visible = false;
                ribbonPage4.Visible = false;
                ribbonPage5.Visible = false;
                ribbonPage6.Visible = false;
            }
        }

        private void frmMAIN_Load(object sender, EventArgs e)
        {
            comboBoxEdit1_SelectedIndexChanged(sender, e);
            barSubQUYTRINH.Enabled = false;
        }

        private void barButtonItem41_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmQUYEN));
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmVAITRO));
        }

        private void barButtonItem42_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPHANQUYEN));
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNGUOIDUNG));
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barbtnNHANSU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmQT_NHANSU));
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPHANLOAIMATHANG));
        }

        private void barbtnTAICHINH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmQT_TAICHINH));
        }

        private void barbtnNHAPHANG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmQT_NHAPHANG));
        }

        private void barbtnBANHANG_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmQT_BANHANG));
        }
    }
}
