using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class KHENTHUONGKYLUATBUS : BaseBus, IStandardBus<KHENTHUONGKYLUAT>
    {
        public List<KHENTHUONGKYLUAT> GetAll()
        {
            return db.KHENTHUONGKYLUATs.ToList();
        }
        public KHENTHUONGKYLUAT GetById(int id)
        {
            return db.KHENTHUONGKYLUATs.Find(id);
        }
        public void Post(KHENTHUONGKYLUAT obj)
        {
            db.KHENTHUONGKYLUATs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, KHENTHUONGKYLUAT newObj)
        {
            var oldObj = db.KHENTHUONGKYLUATs.Find(id);
            oldObj.SoKhenThuongKyLuat = newObj.SoKhenThuongKyLuat;
            oldObj.NoiDung = newObj.NoiDung;
            oldObj.NgayQuyetDinh = newObj.NgayQuyetDinh;
            oldObj.MaNV = newObj.MaNV;
            oldObj.LoaiKhenThuongKyLuat = newObj.LoaiKhenThuongKyLuat;
            oldObj.LyDo = newObj.LyDo;
            oldObj.NgayBatDau = newObj.NgayBatDau;
            oldObj.NgayKetThuc = newObj.NgayKetThuc;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.KHENTHUONGKYLUATs.Find(id);
            db.KHENTHUONGKYLUATs.Remove(obj);
            db.SaveChanges();
        }
    }
}
