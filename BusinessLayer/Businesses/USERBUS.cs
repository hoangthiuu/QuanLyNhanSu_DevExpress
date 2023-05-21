using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class USERBUS : BaseBus
    {
        /*
         * CƠ CHẾ QUẢN LÝ MẬT KHẨU:
         *  Không lưu mật khẩu dạng plantext vào database vì yêu cầu bảo mật thông tin tài khoản
         *  Phải mã hoá, hash password trước khi lưu vào database
         *  Khi đăng nhập, sẽ dùng mật khẩu nhập vào, hash nó, nó sánh với mật khẩu đã lưu trong database để xác thực thông tin
         *  --> Sử dụng thuật toán Bycrypt để hash và mã hoá mật khẩu
         * 
         * 
         *  B1. Xoá bảng USER cũ đi
         *  B2. Update lại bảng USER
         *  đặt trường MatKhau là NVARCHAR(MAX) NOT NULL, (phải để là NVARCHAR !!!)
         * 
         *  B3. Cài đặt nuget Brcypt.Net trong NugetPackage (đã cài rồi !!!)
         *  B4. Chạy phương thức CreateUser để lưu thông tin user vào database
         *  B5. Khi đăng nhập, sử dụng phương thức CheckLoginInfo để kiểm tra thông tin đăng nhập 
         */

        /// <summary>
        ///  Tạo User
        /// </summary>
        /// <param name="username">username của tài khoản (dạng plantext)</param>
        /// <param name="password">password của tài khoản (dạng plantext), password này sẽ được hash bằng Bcrypt rồi lưu vào databse</param>
        public void CreateUser(string username, string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            var user = new USER()
            {
                TenDangNhap = username,
                MatKhau = hashPassword
            };
            db.USERs.Add(user);
            db.SaveChanges();
        }

        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// </summary>
        /// <param name = "username" > username của tài khoản(dạng plantext)</param>
        /// <param name = "password" > password của tài khoản(dạng plantext), password này sẽ được verify với hashedPassword đã lưu databse để xác minh</param>
        /// <returns>
        /// bool: Kết quả Login: Sucess | Fail
        /// </returns>
        public bool CheckLoginInfo(string username, string password)
        {
            var user = db.USERs.FirstOrDefault(x => x.TenDangNhap == username); // kiểm tra username có tồn tại không???

            if (user == null) // username không tồn tại --> đăng nhập thất bại
            {
                return false;
            }
            else // username tồn tại --> tiếp tục kiểm tra password
            {
                var hashedPassword = user.MatKhau;
                var check = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                if (!check) // password sai --> đăng nhập thất bại
                {
                    return false;
                }
                else // password đúng --> đăng nhập thành công
                {
                    return true;
                }
            }
        }
    }
}
