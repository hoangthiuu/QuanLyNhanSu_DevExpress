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
    public partial class frmLuong : DevExpress.XtraEditors.XtraForm
    {
        // khai bao bien dung chung
        #region Variables 
        LUONGBUS _busLuong;
        FormStatus _status;

        #endregion

        //Khởi tạo các giá trị biến
        #region Constructor
        public frmLuong()
        {
            _status = FormStatus.View;
            _busLuong = new LUONGBUS();
            InitializeComponent();
        }
        #endregion

        #region EvenHandler
        private void frmLuong_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;// khóa lưới không cho sửa trục tiếp trên lưới
            ConfigButtonManager();
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
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BacLuong"));
                _busLuong.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_status == FormStatus.Create)
            {
                var obj = new LUONG
                {
                    LuongCoBan = CommonHandler.ConvertToNullableDouble(edLuongCoBan.EditValue),
                   

                };

                _busLuong.Post(obj);
            }

            else if (_status == FormStatus.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BacLuong"));
                var obj = new LUONG
                {
                    BacLuong = id,
                    LuongCoBan = CommonHandler.ConvertToNullableDouble(edLuongCoBan.EditValue),
                  
                };
                _busLuong.Put(id, obj);
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
            // edTenLuong.EditValue = grid.GetFocusedRowCellValue("TenLuong").ToString();
            edLuongCoBan.EditValue =Convert.ToInt32(grid.GetFocusedRowCellValue("LuongCoBan"));
           
        }
        #endregion

        #region Process
        private void LoadDataGrid()
        {
            var data = _busLuong.GetAll();
            gridControl1.DataSource = data;
        }
        private void ConfigButtonManager()
        {
            if (_status == FormStatus.View)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = false;
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
                edHeSoPhuCap.ReadOnly = true;
                edLuongCoBan.ReadOnly = true;
            }
            else if (_status == FormStatus.Create || _status == FormStatus.Edit)
            {
                edHeSoPhuCap.ReadOnly = false;
                edLuongCoBan.ReadOnly = false;
            }
        }

        private void ClearEditControll()
        {
              edLuongCoBan.EditValue = null;
              edHeSoPhuCap.EditValue = null;
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
            MessageBox.Show("File đã lưu ở C:\\Reports\\MyReport_Luong.pdf ");
        }
    }
}