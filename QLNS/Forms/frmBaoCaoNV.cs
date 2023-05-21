using BusinessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLNS.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS.Forms
{
    public partial class frmBaoCaoNV : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoNV()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            var bus = new NHANVIENBUS();
           
            var data = bus.GetAll();
            var report = new RptDsNhanVien(data);

            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}