using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNS
{
    public class FlatKhenThuongKyLuatDTO
    {
        public int IdKhenThuongKyLuat { get; set; }
        public string SoKhenThuongKyLuat { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayQuyetDinh { get; set; }
        public int? MaNV { get; set; }
        public string HoTen { get; set; }
        public string LoaiKhenThuongKyLuat { get; set; }
        public string LyDo { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
    }
}
