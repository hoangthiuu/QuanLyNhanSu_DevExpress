using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class LUONGBUS : BaseBus, IStandardBus<LUONG>
    {
        public List<LUONG> GetAll()
        {
            return db.LUONGs.ToList();
        }
        public LUONG GetById(int id)
        {
            return db.LUONGs.Find(id);
        }
        public void Post(LUONG obj)
        {
            db.LUONGs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, LUONG newObj)
        {
            var oldObj = db.LUONGs.Find(id);
            oldObj.LuongCoBan = newObj.LuongCoBan;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.LUONGs.Find(id);
            db.LUONGs.Remove(obj);
            db.SaveChanges();
        }
    }
}
