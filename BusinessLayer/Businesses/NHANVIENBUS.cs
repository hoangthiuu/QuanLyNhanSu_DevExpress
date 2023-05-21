using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class NHANVIENBUS : BaseBus, IStandardBus<NHANVIEN>
    {
        public List<NHANVIEN> GetAll()
        {
            return db.NHANVIENs.ToList();
        }
        public NHANVIEN GetById(int id)
        {
            return db.NHANVIENs.Find(id);
        }
        public void Post(NHANVIEN obj)
        {
            db.NHANVIENs.Add(obj);
            db.SaveChanges();
        }
        public void Put(int id, NHANVIEN newObj)
        {
            var oldObj = db.NHANVIENs.Find(id);
            oldObj.HoTen = newObj.HoTen;
            oldObj.GioiTinh = newObj.GioiTinh;
            oldObj.NgaySinh = newObj.NgaySinh;
            oldObj.DiaChi = newObj.DiaChi;
            oldObj.DienThoai = newObj.DienThoai;
            oldObj.CCCD = newObj.CCCD;
            oldObj.HeSoLuong = newObj.HeSoLuong;
            oldObj.HinhAnh = newObj.HinhAnh;
            oldObj.IdPhongBan = newObj.IdPhongBan;
            oldObj.IdChucVu = newObj.IdChucVu;
            oldObj.IdTrinhDo = newObj.IdTrinhDo;
            oldObj.IdDanToc = newObj.IdDanToc;
            oldObj.IdTonGiao = newObj.IdTonGiao;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.NHANVIENs.Find(id);
            db.NHANVIENs.Remove(obj);
            db.SaveChanges();
        }

        
    }
}
