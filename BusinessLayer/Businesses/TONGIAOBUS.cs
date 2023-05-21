using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class TONGIAOBUS : BaseBus, IStandardBus<TONGIAO>
    {
        public List<TONGIAO> GetAll()
        {
            return db.TONGIAOs.ToList();
        }
        public TONGIAO GetById(int id)
        {
            return db.TONGIAOs.Find(id);
        }
        public void Post(TONGIAO obj)
        {
            db.TONGIAOs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, TONGIAO newObj)
        {
            var oldObj = db.TONGIAOs.Find(id);
            oldObj.TenTonGiao = newObj.TenTonGiao;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.TONGIAOs.Find(id);
            db.TONGIAOs.Remove(obj);
            db.SaveChanges();
        }
    }
}
