using BusinessLayer;
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

namespace QLNS
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        USERBUS _userBus;

        public frmLogin()
        {
            _userBus = new USERBUS();
            InitializeComponent();

            //_userBus.CreateUser("admin", "admin");
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            var username = CommonHandler.ConvertToNullableString(txtTenDangNhap.EditValue);
            var password = CommonHandler.ConvertToNullableString(txtMatKhau.EditValue);

            var resultCheckLogin = _userBus.CheckLoginInfo(username, password);
            if(resultCheckLogin == true)
            {
                XtraMessageBox.Show("Đăng nhập thành công !!! ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MainForm f = new MainForm();
                f.Show();
            }
            else
            {
                XtraMessageBox.Show("Tên tài khoản hoặc mật khẩu nhập sai, yêu cầu nhập lại để đăng nhập hệ thống ", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}