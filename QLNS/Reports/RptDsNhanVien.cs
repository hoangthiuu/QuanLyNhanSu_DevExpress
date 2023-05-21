using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLNS.Reports
{
    public partial class RptDsNhanVien : DevExpress.XtraReports.UI.XtraReport
    {
        public RptDsNhanVien(object datasource)
        {
            InitializeComponent();
            this.DataSource = datasource;
        }

    }
}
