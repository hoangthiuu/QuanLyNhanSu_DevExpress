using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLNS.Reports
{
    public partial class RptDsKhenThuong : DevExpress.XtraReports.UI.XtraReport
    {
        public RptDsKhenThuong(object datasource)
        {
            InitializeComponent();
            this.DataSource = datasource;
        }

    }
}
