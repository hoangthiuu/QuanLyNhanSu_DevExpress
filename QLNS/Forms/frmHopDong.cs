using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
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

namespace QLNS
{
    public partial class frmHopDong : DevExpress.XtraEditors.XtraForm
    {
        // khai bao bien dung chung
        #region Variables 
        HOPDONGBUS _busHopDong;
        NHANVIENBUS _busNhanVien;
        Status _status;

        enum Status // kiểu liệt kê
        {
            View = 0,
            Create = 1,
            Edit = 2,
        }
        #endregion

        //Khởi tạo các giá trị biến
        #region Constructor
        public frmHopDong()
        {
            _status = Status.View;
            _busHopDong = new HOPDONGBUS();
            _busNhanVien = new NHANVIENBUS();
            InitializeComponent();
        }
        #endregion

        #region EvenHandler
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            LoadDataRepo();
            ConfigButtonManager();
            LoadDataGrid();
           
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = Status.Create;
            ConfigButtonManager();
            ClearEditControll();
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = Status.Edit;
            ConfigButtonManager();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Có chắc chắn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdHopDong"));
                _busHopDong.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_status == Status.Create)
            {
                var obj = new HOPDONG
                {
                    NoiDung = CommonHandler.ConvertToNullableString(edNoiDung.EditValue),
                    NgayBatDau = CommonHandler.ConvertToNullableDateTime(edNgayBatDau.EditValue),
                    NgayKetThuc = CommonHandler.ConvertToNullableDateTime(edNgayKetThuc.EditValue),
                    NgayKy = CommonHandler.ConvertToNullableDateTime(edNgayKy.EditValue),
                    LanKy = CommonHandler.ConvertToNullabeInt(edLanKy.EditValue),
                    MaNV = CommonHandler.ConvertToNullabeInt(edNhanVien.EditValue),
                    
                };
                _busHopDong.Post(obj);
            }
            else if (_status == Status.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdHopDong"));
                var obj = new HOPDONG
                {
                    IdHopDong=id,
                    NoiDung = CommonHandler.ConvertToNullableString(edNoiDung.EditValue),
                    NgayBatDau = CommonHandler.ConvertToNullableDateTime(edNgayBatDau.EditValue),
                    NgayKetThuc = CommonHandler.ConvertToNullableDateTime(edNgayKetThuc.EditValue),
                    NgayKy = CommonHandler.ConvertToNullableDateTime(edNgayKy.EditValue),
                    LanKy = CommonHandler.ConvertToNullabeInt(edLanKy.EditValue),
                    MaNV = CommonHandler.ConvertToNullabeInt(edNhanVien.EditValue),
                };
                _busHopDong.Put(id, obj);
            }

            LoadDataGrid();
            _status = Status.View;
            ConfigButtonManager();
        }
        
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = Status.View;
            ConfigButtonManager();
        }
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = sender as GridView;
            edLanKy.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("LanKy"));
            edNgayBatDau.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgayBatDau"));
            edNgayKetThuc.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgayKetThuc"));
            edNgayKy.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgayKy"));
            edNoiDung.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("NoiDung"));
            edNhanVien.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("MaNV"));
        }
        #endregion


        #region Process
        private void LoadDataRepo()
        {
            var dataNhanVien = _busNhanVien.GetAll();

            // load dl vào trường chọn 
            CommonHandler.LoadFromObject(edNhanVien, dataNhanVien, "MaNV", "HoTen");

        }

        private void LoadDataGrid()
        {
            var data = _busHopDong.GetAll();
            gridControl1.DataSource = data;
        }
        private void ConfigButtonManager()
        {
            if (_status == Status.View)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
                btnDong.Enabled = true;
            }
            else if (_status == Status.Create || _status == Status.Edit)
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
            if (_status == Status.View)
            {
                edNoiDung.ReadOnly = true;
                edLanKy.ReadOnly = true;
                edNgayBatDau.ReadOnly = true;
                edNgayKetThuc.ReadOnly = true;
                edNgayKy.ReadOnly = true;
                edNhanVien.ReadOnly = true;

            }
            else if (_status == Status.Create || _status == Status.Edit)
            {
                edNoiDung.ReadOnly = false;
                edLanKy.ReadOnly = false;
                edNgayBatDau.ReadOnly = false;
                edNgayKetThuc.ReadOnly = false;
                edNgayKy.ReadOnly = false;
                edNhanVien.ReadOnly = false;
            }
        }
        #endregion

        private void ClearEditControll()
        {
            edNoiDung.EditValue = null;
            edLanKy.EditValue = null;
            edNgayBatDau.EditValue = null;
            edNgayKetThuc.EditValue = null;
            edNgayKy.EditValue = null;
            edNhanVien.EditValue = null;
        }
    }
}