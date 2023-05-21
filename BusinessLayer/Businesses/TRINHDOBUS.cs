using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class TRINHDOBUS : BaseBus, IStandardBus<TRINHDO>
    {
        public List<TRINHDO> GetAll()
        {
            return db.TRINHDOes.ToList();
        }
        public TRINHDO GetById(int id)
        {
            return db.TRINHDOes.Find(id);
        }
        public void Post(TRINHDO obj)
        {
            db.TRINHDOes.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, TRINHDO newObj)
        {
            var oldObj = db.TRINHDOes.Find(id);
            oldObj.TenTrinhDo = newObj.TenTrinhDo;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.TRINHDOes.Find(id);
            db.TRINHDOes.Remove(obj);
            db.SaveChanges();
        }
    }
}
