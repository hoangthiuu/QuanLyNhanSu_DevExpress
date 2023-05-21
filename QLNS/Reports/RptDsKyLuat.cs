using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLNS.Reports
{
    public partial class RptDsKyLuat : DevExpress.XtraReports.UI.XtraReport
    {
        public RptDsKyLuat(object datasource)
        {
            InitializeComponent();
            this.DataSource = datasource;
        }

    }
}
