using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class NHANVIENLUONGBUS : BaseBus, IStandardBus<NHANVIEN_LUONG>
    {
        public List<NHANVIEN_LUONG> GetAll()
        {
            return db.NHANVIEN_LUONG.ToList();
        }
        public NHANVIEN_LUONG GetById(int id)
        {
            return db.NHANVIEN_LUONG.Find(id);
        }
        public void Post(NHANVIEN_LUONG obj)
        {
            db.NHANVIEN_LUONG.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, NHANVIEN_LUONG newObj)
        {
            var oldObj = db.NHANVIEN_LUONG.FirstOrDefault(x => x.IdNhanVienLuong == id);
            oldObj.MaNV = newObj.MaNV;
            oldObj.BacLuong = newObj.BacLuong;
            oldObj.KhoanCong = newObj.KhoanCong;
            oldObj.KhoanTru = newObj.KhoanTru;
            oldObj.LyDoCong = newObj.LyDoCong;
            oldObj.LyDoTru = newObj.LyDoTru;
            oldObj.ThucLinh = newObj.ThucLinh;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.NHANVIEN_LUONG.FirstOrDefault(x => x.IdNhanVienLuong == id);
            db.NHANVIEN_LUONG.Remove(obj);
            db.SaveChanges();
        }
    }
}
