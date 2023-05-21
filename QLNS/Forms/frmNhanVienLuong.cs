using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using static QLNS.CommonVariables;

namespace QLNS
{
    public partial class frmNhanVienLuong : DevExpress.XtraEditors.XtraForm
    {
        // khai bao bien dung chung
        #region Variables 
        NHANVIENLUONGBUS _busNhanVienLuong;
        NHANVIENBUS _busNhanVien;
        LUONGBUS _busLuong;
        CHUCVUBUS _busChucVu;
        FormStatus _status;
        #endregion

        //Khởi tạo các giá trị biến
        #region Constructor
        public frmNhanVienLuong()
        {
            _status = FormStatus.View;
            _busNhanVien = new NHANVIENBUS();
            _busNhanVienLuong = new NHANVIENLUONGBUS();
            _busLuong = new LUONGBUS();
            _busChucVu = new CHUCVUBUS();
           
            InitializeComponent();
        }
        #endregion

        #region EvenHandler
        private void frmNhanVienLuong_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;// khóa lưới không cho sửa trục tiếp trên lưới
            ConfigButtonManager();
            LoadDataRepo();
            LoadDataGrid();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = FormStatus.Create;
            ConfigButtonManager();
            ClearEditControll();
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = FormStatus.Edit;
            ConfigButtonManager();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Có chắc chắn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdNhanVienLuong"));
                _busNhanVienLuong.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_status == FormStatus.Create)
            {
                var obj = new NHANVIEN_LUONG
                {
                    LyDoCong = CommonHandler.ConvertToNullableString(edLyDoCong.EditValue),
                    LyDoTru = CommonHandler.ConvertToNullableString(edLyDoTru.EditValue),
                    KhoanCong = CommonHandler.ConvertToNullableDouble(edKhoanCong.EditValue),
                    KhoanTru = CommonHandler.ConvertToNullableDouble(edKhoanTru.EditValue),
                    BacLuong = (int)CommonHandler.ConvertToNullabeInt(edBacLuong.EditValue),
                    MaNV = (int)CommonHandler.ConvertToNullabeInt(edNhanVien.EditValue),
                };
                obj.ThucLinh = CalculateThucLinh(obj);
                _busNhanVienLuong.Post(obj);
            }
            else if (_status == FormStatus.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdNhanVienLuong"));
                var obj = new NHANVIEN_LUONG
                {
                    IdNhanVienLuong = id,
                    LyDoCong = CommonHandler.ConvertToNullableString(edLyDoCong.EditValue),
                    LyDoTru = CommonHandler.ConvertToNullableString(edLyDoTru.EditValue),
                    KhoanCong = CommonHandler.ConvertToNullableDouble(edKhoanCong.EditValue),
                    KhoanTru = CommonHandler.ConvertToNullableDouble(edKhoanTru.EditValue),
                    BacLuong = (int)CommonHandler.ConvertToNullabeInt(edBacLuong.EditValue),
                    MaNV = (int)CommonHandler.ConvertToNullabeInt(edNhanVien.EditValue)
                };
                obj.ThucLinh = CalculateThucLinh(obj);
                _busNhanVienLuong.Put(id, obj);
            }

            LoadDataGrid();
            _status = FormStatus.View;
            ConfigButtonManager();
        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = FormStatus.View;
            ConfigButtonManager();
        }
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = sender as GridView;
            edLyDoCong.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("LyDoCong"));
            edLyDoTru.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("LyDoTru"));
            edKhoanCong.EditValue = CommonHandler.ConvertToNullableDouble(grid.GetFocusedRowCellValue("KhoanCong"));
            edKhoanTru.EditValue = CommonHandler.ConvertToNullableDouble(grid.GetFocusedRowCellValue("KhoanTru"));
            edNhanVien.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("MaNV"));
            edBacLuong.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("BacLuong"));
        }
        #endregion

        #region Process

        private void LoadDataRepo()
        {
            var dataNhanVien = _busNhanVien.GetAll();
            var dataBacLuong = _busLuong.GetAll();

            // load dl vào trường chọn 
            CommonHandler.LoadFromObject(edNhanVien, dataNhanVien, "MaNV", "HoTen");
            CommonHandler.LoadFromObject(edBacLuong, dataBacLuong, "BacLuong", "BacLuong");

            // load dl vào lưới hiển thị
            CommonHandler.LoadFromObject(repoNhanVien, dataNhanVien, "MaNV", "HoTen");
            CommonHandler.LoadFromObject(repoBacLuong, dataBacLuong, "BacLuong", "BacLuong");

        }

        private void LoadDataGrid()
        {
            var data = _busNhanVienLuong.GetAll();
            gridControl1.DataSource = data;
        }


        private void ConfigButtonManager()
        {
            if (_status == FormStatus.View)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnDong.Enabled = true;
            }
            else if (_status == FormStatus.Create || _status == FormStatus.Edit)
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
                btnDong.Enabled = false;
            }
            ConfigEditControl();
        }
        private void ConfigEditControl()
        {
            if (_status == FormStatus.View)
            {
                edKhoanCong.ReadOnly = true;
                edBacLuong.ReadOnly = true;
                edKhoanTru.ReadOnly = true;
                edLyDoTru.ReadOnly = true;
                edLyDoCong.ReadOnly = true;
                edNhanVien.ReadOnly = true;

            }
            else if (_status == FormStatus.Create || _status == FormStatus.Edit)
            {
                edKhoanCong.ReadOnly = false;
                edBacLuong.ReadOnly = false;
                edKhoanTru.ReadOnly = false;
                edLyDoTru.ReadOnly = false;
                edLyDoCong.ReadOnly = false;
                edNhanVien.ReadOnly = false;
            }
        }

        private void ClearEditControll()
        {
            edBacLuong.EditValue = null;
            edKhoanCong.EditValue = null;
            edKhoanTru.EditValue = null;
            edLyDoCong.EditValue = null;
            edLyDoTru.EditValue = null;
            edNhanVien.EditValue = null;

        } //hao tác chọn nút HỦY: tất cả các trạng thái chuyển về giá trị null
        #endregion

        private double? CalculateThucLinh(NHANVIEN_LUONG objNhanVienLuong)
        {
            try
            {
                var objNhanVien = _busNhanVien.GetById(objNhanVienLuong.MaNV);
                var objLuong = _busLuong.GetById(objNhanVienLuong.BacLuong);
                var objChucVu = _busChucVu.GetById((int)objNhanVien.IdChucVu);

                var luongCoBan = objLuong.LuongCoBan;
                var heSoPhuCap = objChucVu.HeSoPhuCap;
                var heSoLuong = objNhanVien.HeSoLuong;
                var khoanCong = objNhanVienLuong.KhoanCong;
                var khoanTru = objNhanVienLuong.KhoanTru;
                var thucLinh = luongCoBan * (heSoPhuCap + heSoLuong) + khoanCong - khoanTru;

                return thucLinh;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}