using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class CHUCVUBUS : BaseBus, IStandardBus<CHUCVU>
    {
        public List<CHUCVU> GetAll()
        {
            return db.CHUCVUs.ToList();
        }
        public CHUCVU GetById(int id)
        {
            return db.CHUCVUs.Find(id);
        }
        public void Post(CHUCVU obj)
        {
            db.CHUCVUs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, CHUCVU newObj)
        {
            var oldObj = db.CHUCVUs.Find(id);
            oldObj.TenChucVu = newObj.TenChucVu;
            oldObj.HeSoPhuCap = newObj.HeSoPhuCap;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.CHUCVUs.Find(id);
            db.CHUCVUs.Remove(obj);
            db.SaveChanges();
        }
    }
}
