using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class BAOHIEMBUS : BaseBus, IStandardBus<BAOHIEM>
    {
        public List<BAOHIEM> GetAll()
        {
            return db.BAOHIEMs.ToList();
        }
        public BAOHIEM GetById(int id)
        {
            return db.BAOHIEMs.Find(id);
        }
        public void Post(BAOHIEM obj)
        {
            db.BAOHIEMs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, BAOHIEM newObj)
        {
            var oldObj = db.BAOHIEMs.Find(id);
            oldObj.SoBH = newObj.SoBH;
            oldObj.NgayCap = newObj.NgayCap;
            oldObj.NoiCap = newObj.NoiCap;
            oldObj.NoiKhamBenh = newObj.NoiKhamBenh;
            oldObj.MaNV = newObj.MaNV;
            db.SaveChanges();
          
        }
        public void Delete(int id)
        {
            var obj = db.BAOHIEMs.Find(id);
            db.BAOHIEMs.Remove(obj);
            db.SaveChanges();
        }
    }
}
