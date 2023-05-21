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
    public partial class frmRestore : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection con = new SqlConnection(@"server = DESKTOP-V09APVR\SQLEXPRESS;initial catalog=QLNS1;integrated security=True");
        public frmRestore()
        {
            InitializeComponent();
        }

        private void btnBrowserBackUp_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = dlg.FileName;
                btnRestore.Enabled = true;
            }
        }

        private void btnRestore_Click_1(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();
            try
            {
                string str1 = $"ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                SqlCommand cmd1 = new SqlCommand(str1,con);
                cmd1.ExecuteNonQuery();

                string str2 = $"USE MASTER RESTORE DATABASE [{database}] FROM DISK='{txtLocation.Text}' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(str2,con);
                cmd2.ExecuteNonQuery();

                string str3 = $"ALTER DATABASE [{database}] SET MULTI_USER";
                SqlCommand cmd3 = new SqlCommand(str3, con);
                cmd3.ExecuteNonQuery();

                MessageBox.Show("Database restore thành công !!!");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}