using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class DANTOCBUS : BaseBus, IStandardBus<DANTOC>
    {
        public List<DANTOC> GetAll()
        {
            return db.DANTOCs.ToList();
        }
        public DANTOC GetById(int id)
        {
            return db.DANTOCs.Find(id);
        }
        public void Post(DANTOC obj)
        {
            db.DANTOCs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, DANTOC newObj)
        {
            var oldObj = db.DANTOCs.Find(id);
            oldObj.TenDanToc = newObj.TenDanToc;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.DANTOCs.Find(id);
            db.DANTOCs.Remove(obj);
            db.SaveChanges();
        }
    }
}
