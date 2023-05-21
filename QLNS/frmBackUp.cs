using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLNS
{
    public partial class frmBackUp : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con = new SqlConnection(@"server = DESKTOP-V09APVR\SQLEXPRESS;initial catalog=QLNS1;integrated security=True");
        public frmBackUp()
        {
            InitializeComponent();
        }

        private void btnBrowserBackUp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.SelectedPath;
                btnBackUp.Enabled = true;
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if (txtLocation.Text == string.Empty)
            {
                MessageBox.Show("Chọn địa chỉ file location");
            }
            else
            {
                string cmd = "backup database " + database + " to disk = '" + txtLocation.Text + @"\QLNS.bak'";
                con.Open();
                SqlCommand command = new SqlCommand(cmd, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Database bakup thành công !!!");
                con.Close();
            }
        }


    }
}



