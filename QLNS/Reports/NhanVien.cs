using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLNS
{
    public partial class NhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public NhanVien(object datasource)
        {
            InitializeComponent();
            this.DataSource = datasource;
        }
    }
}
