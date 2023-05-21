using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class USERBUS1 : BaseBus
    {
        public List<USER> GetAll()
        {
            return db.USERs.ToList();
        }
        public USER GetById(int id)
        {
            return db.USERs.Find(id);
        }
        public void Post(USER obj)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(obj.MatKhau, salt);
            obj.MatKhau = hashPassword;

            db.USERs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, USER newObj)
        {
            var oldObj = db.USERs.Find(id);
            oldObj.TenDangNhap = newObj.TenDangNhap;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.USERs.Find(id);
            db.USERs.Remove(obj);
            db.SaveChanges();
        }
    }
}
