using DevExpress.Skins;
using DevExpress.UserSkins;
using GUI.QL_NHAP_KHO_GUI;
using GUI.QL_PHAN_QUYEN;
using GUI.QL_TAI_CHINH_GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMAIN());
        }
    }
}
