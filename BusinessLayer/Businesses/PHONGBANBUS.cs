using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class PHONGBANBUS : BaseBus, IStandardBus<PHONGBAN>
    {
        public List<PHONGBAN> GetAll()
        {
            return db.PHONGBANs.ToList();
        }
        public PHONGBAN GetById(int id)
        {
            return db.PHONGBANs.Find(id);
        }
        public void Post(PHONGBAN obj)
        {
            db.PHONGBANs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, PHONGBAN newObj)
        {
            var oldObj = db.PHONGBANs.Find(id);
            oldObj.TenPhongBan = newObj.TenPhongBan;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.PHONGBANs.Find(id);
            db.PHONGBANs.Remove(obj);
            db.SaveChanges();
        }
    }
}
