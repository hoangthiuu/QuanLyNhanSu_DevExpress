using BusinessLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using QLNS.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS.Forms
{
    public partial class frmBaoCaoKyLuat : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoKyLuat()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            var busKhenThuongKyLuat = new KHENTHUONGKYLUATBUS();
            var busNhanVien = new NHANVIENBUS();

            var dataKhenThuongKyLuat = busKhenThuongKyLuat.GetAll().Where(x=>x.LoaiKhenThuongKyLuat == "Kỷ luật");
            var dataFlatKyLuat = new List<FlatKhenThuongKyLuatDTO>();
            foreach(var item in dataKhenThuongKyLuat)
            {
                var obj = new FlatKhenThuongKyLuatDTO
                {
                    IdKhenThuongKyLuat = item.IdKhenThuongKyLuat,
                    SoKhenThuongKyLuat = item.SoKhenThuongKyLuat,
                    NoiDung = item.NoiDung,
                    NgayQuyetDinh = item.NgayQuyetDinh,
                    LoaiKhenThuongKyLuat = item.LoaiKhenThuongKyLuat,
                    MaNV = item.MaNV,
                    HoTen = busNhanVien.GetById(Convert.ToInt32(item.MaNV)).HoTen,
                    LyDo = item.LyDo,
                    NgayBatDau = item.NgayBatDau,
                    NgayKetThuc = item.NgayKetThuc,
                };
                dataFlatKyLuat.Add(obj);
            }


            var report = new RptDsKyLuat(dataFlatKyLuat);

            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}