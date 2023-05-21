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
    public partial class frmUser1 : DevExpress.XtraEditors.XtraForm
    {
        // khai bao bien dung chung
        #region Variables 
        USERBUS1 _busUser1;
        FormStatus _FormStatus;

        #endregion

        //Khởi tạo các giá trị biến
        #region Constructor
        public frmUser1()
        {
            _FormStatus = FormStatus.View;
            _busUser1 = new USERBUS1();
            InitializeComponent();
        }
        #endregion

        #region EvenHandler

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
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdNguoiDung"));
                _busUser1.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_FormStatus == FormStatus.Create)
            {
                var obj = new USER
                {
                    TenDangNhap= CommonHandler.ConvertToNullableString(edTenDangNhap.EditValue),
                    TenNguoiDung = CommonHandler.ConvertToNullableString(edTenNguoiDung.EditValue),
                    MatKhau= CommonHandler.ConvertToNullableString(edMatKhau.EditValue),
                };

                _busUser1.Post(obj);
            }

            else if (_FormStatus == FormStatus.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdNguoiDung"));
                var obj = new USER
                {
                    MatKhau = CommonHandler.ConvertToNullableString(edTenNguoiDung.EditValue),
                };
                _busUser1.Put(id, obj);
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
            edTenNguoiDung.EditValue = grid.GetFocusedRowCellValue("TenNguoiDung").ToString();
            edTenDangNhap.EditValue = grid.GetFocusedRowCellValue("TenDangNhap").ToString();
            edMatKhau.EditValue = grid.GetFocusedRowCellValue("MatKhau").ToString();
        }
        #endregion

        #region Process
        private void LoadDataGrid()
        {
            var data = _busUser1.GetAll();
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
                edTenNguoiDung.ReadOnly = true;
                edTenDangNhap.ReadOnly = true;
                edMatKhau.ReadOnly = true;
            }
            else if (_FormStatus == FormStatus.Edit)
            {
                edTenNguoiDung.ReadOnly = true;
                edTenDangNhap.ReadOnly = true;
                edMatKhau.ReadOnly = false;
            }
            else if (_FormStatus == FormStatus.Create )
            {
                edTenNguoiDung.ReadOnly = false;
                edTenDangNhap.ReadOnly = false;
                edMatKhau.ReadOnly = false;
            }
        }

        private void ClearEditControll()
        {
            edTenNguoiDung.EditValue = null;
            edMatKhau.EditValue = null;
            edTenDangNhap.EditValue = null;
        }
        #endregion

            public void ExportToPdf(GridView gridView, string filePath)
        {
            PdfExportOptions options = new PdfExportOptions();
            options.ShowPrintDialogOnOpen = true; // Change this to false if you don't want the print dialog to show up
            gridView.ExportToPdf(filePath, options);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ExportToPdf(gridView1, "C:\\Reports\\MyReport.pdf");
            MessageBox.Show("File đã lưu ở C:\\Reports\\MyReport_TrinhDo.pdf ");
        }

        private void frmUser1_Load_1(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;// khóa lưới không cho sửa trục tiếp trên lưới
            ConfigButtonManager();
            LoadDataGrid();
        }
    }
}