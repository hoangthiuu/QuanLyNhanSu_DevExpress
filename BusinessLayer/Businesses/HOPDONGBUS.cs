using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class HOPDONGBUS : BaseBus, IStandardBus<HOPDONG>
    {
        public List<HOPDONG> GetAll()
        {
            return db.HOPDONGs.ToList();
        }
        public HOPDONG GetById(int id)
        {
            return db.HOPDONGs.Find(id);
        }
        public void Post(HOPDONG obj)
        {
            db.HOPDONGs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, HOPDONG newObj)
        {
            var oldObj = db.HOPDONGs.Find(id);
            oldObj.NgayBatDau = newObj.NgayBatDau;
            oldObj.NgayKetThuc = newObj.NgayKetThuc;
            oldObj.NgayKy = newObj.NgayKy;
            oldObj.NoiDung = newObj.NoiDung;
            oldObj.LanKy = newObj.LanKy;
            oldObj.ThoiHan = newObj.ThoiHan;
            oldObj.MaNV = newObj.MaNV;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.HOPDONGs.Find(id);
            db.HOPDONGs.Remove(obj);
            db.SaveChanges();
        }
    }
}
