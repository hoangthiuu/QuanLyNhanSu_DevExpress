using DevExpress.Skins;
using DevExpress.UserSkins;
using QLNS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLNS
{
    static class Program { 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBC1());
        }
    }
}
