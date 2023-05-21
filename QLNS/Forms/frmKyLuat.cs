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
using static QLNS.CommonVariables;

namespace QLNS
{
    public partial class frmKyLuat : DevExpress.XtraEditors.XtraForm
    {
        // khai bao bien dung chung
        #region Variables 
        KHENTHUONGKYLUATBUS _busKhenThuongKyLuat;
        NHANVIENBUS _busNhanVien;
        FormStatus _FormStatus;

        #endregion

        //Khởi tạo các giá trị biến
        #region Constructor
        public frmKyLuat()
        {
            _FormStatus = FormStatus.View;
            _busKhenThuongKyLuat = new KHENTHUONGKYLUATBUS();
            _busNhanVien = new NHANVIENBUS();
            InitializeComponent();
            #endregion
        }
        #region EvenHandler

        private void frmKyLuat_Load(object sender, EventArgs e)
        {
            ConfigButtonManager();
            LoadDataGrid();
            LoadDataRepo();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _FormStatus = FormStatus.Create;
            ConfigButtonManager();
            ClearEditControll();
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _FormStatus = FormStatus.Edit;
            ConfigButtonManager();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Có chắc chắn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdKhenThuongKyLuat"));
                _busKhenThuongKyLuat.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_FormStatus == FormStatus.Create)
            {
                var obj = new KHENTHUONGKYLUAT
                {
                    SoKhenThuongKyLuat = CommonHandler.ConvertToNullableString(edSoKyLuat.EditValue),
                    NoiDung = CommonHandler.ConvertToNullableString(edNoiDung.EditValue),
                    LyDo = CommonHandler.ConvertToNullableString(edLyDo.EditValue),
                    NgayQuyetDinh = CommonHandler.ConvertToNullableDateTime(edNgayQuyetDinh.EditValue),
                    NgayBatDau = CommonHandler.ConvertToNullableDateTime(edNgayBatDau.EditValue),
                    NgayKetThuc = CommonHandler.ConvertToNullableDateTime(edNgayKetThuc.EditValue),
                    MaNV = CommonHandler.ConvertToNullabeInt(edNhanVien.EditValue),
                    LoaiKhenThuongKyLuat = "Kỷ luật",
                };
                _busKhenThuongKyLuat.Post(obj);
            }
            else if (_FormStatus == FormStatus.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdKhenThuongKyLuat"));
                var obj = new KHENTHUONGKYLUAT
                {
                    IdKhenThuongKyLuat = id,
                    SoKhenThuongKyLuat = CommonHandler.ConvertToNullableString(edSoKyLuat.EditValue),
                    NoiDung = CommonHandler.ConvertToNullableString(edNoiDung.EditValue),
                    LyDo = CommonHandler.ConvertToNullableString(edLyDo.EditValue),
                    NgayQuyetDinh = CommonHandler.ConvertToNullableDateTime(edNgayQuyetDinh.EditValue),
                    NgayBatDau = CommonHandler.ConvertToNullableDateTime(edNgayBatDau.EditValue),
                    NgayKetThuc = CommonHandler.ConvertToNullableDateTime(edNgayKetThuc.EditValue),
                    MaNV = CommonHandler.ConvertToNullabeInt(edNhanVien.EditValue),
                    LoaiKhenThuongKyLuat = "Kỷ luật",
                };
                _busKhenThuongKyLuat.Put(id, obj);
            }
            LoadDataGrid();
            _FormStatus = FormStatus.View;
            ConfigButtonManager();
        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _FormStatus = FormStatus.View;
            ConfigButtonManager();
        }
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = sender as GridView;
            edSoKyLuat.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("SoKhenThuongKyLuat"));
            edNoiDung.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("NoiDung"));
            edLyDo.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("LyDo"));
            edNgayQuyetDinh.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgayQuyetDinh"));
            edNgayBatDau.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgayBatDau"));
            edNgayKetThuc.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgayKetThuc"));
            edNhanVien.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("MaNV"));

        }
        private void LoadDataRepo()
        {
            var dataNhanVien = _busNhanVien.GetAll();

            // load dl vào trường chọn 
            CommonHandler.LoadFromObject(edNhanVien, dataNhanVien, "MaNV", "HoTen");

            // load dl vào lưới hiển thị
            CommonHandler.LoadFromObject(repoNhanVien, dataNhanVien, "MaNV", "HoTen");
        }

        #endregion

        #region Process
        private void LoadDataGrid()
        {
            var data = _busKhenThuongKyLuat.GetAll().Where(x => x.LoaiKhenThuongKyLuat == "Kỷ luật");
            gridControl1.DataSource = data;
        }
        private void ConfigButtonManager()
        {
            if (_FormStatus == FormStatus.View)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnDong.Enabled = true;
            }
            else if (_FormStatus == FormStatus.Create || _FormStatus == FormStatus.Edit)
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
            if (_FormStatus == FormStatus.View)
            {
                edSoKyLuat.ReadOnly = true;
                edNoiDung.ReadOnly = true;
                edLyDo.ReadOnly = true;
                edNgayQuyetDinh.ReadOnly = true;
                edNgayBatDau.ReadOnly = true;
                edNgayKetThuc.ReadOnly = true;
                edNhanVien.ReadOnly = true;
            }
            else if (_FormStatus == FormStatus.Create || _FormStatus == FormStatus.Edit)
            {
                edSoKyLuat.ReadOnly = false;
                edNoiDung.ReadOnly = false;
                edLyDo.ReadOnly = false;
                edNgayQuyetDinh.ReadOnly = false;
                edNgayBatDau.ReadOnly = false;
                edNgayKetThuc.ReadOnly = false;
                edNhanVien.ReadOnly = false;
            }
        }

        private void ClearEditControll()
        {
            edNhanVien.EditValue = null;
            edNoiDung.EditValue = null;
            edSoKyLuat.EditValue = null;
            edLyDo.EditValue = null;
            edNgayQuyetDinh.EditValue = null;
            edNgayBatDau.EditValue = null;
            edNgayKetThuc.EditValue = null;
        }

        #endregion


    }
}