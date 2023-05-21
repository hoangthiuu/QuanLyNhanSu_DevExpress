﻿using BusinessLayer;
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
    public partial class frmTrinhDo : DevExpress.XtraEditors.XtraForm
    {
        // khai bao bien dung chung
        #region Variables 
        TRINHDOBUS _busTrinhDo;
        FormStatus _FormStatus;

        #endregion

        //Khởi tạo các giá trị biến
        #region Constructor
        public frmTrinhDo()
        {
            _FormStatus = FormStatus.View;
            _busTrinhDo = new TRINHDOBUS();
            InitializeComponent();
        }
        #endregion

        #region EvenHandler
        private void frmTrinhDo_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;// khóa lưới không cho sửa trục tiếp trên lưới
            ConfigButtonManager();
            LoadDataGrid();
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
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdTrinhDo"));
                _busTrinhDo.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_FormStatus == FormStatus.Create)
            {
                var obj = new TRINHDO
                {
                    TenTrinhDo = CommonHandler.ConvertToNullableString(edTenTrinhDo.EditValue),
                };

                _busTrinhDo.Post(obj);
            }

            else if (_FormStatus == FormStatus.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("IdTrinhDo"));
                var obj = new TRINHDO
                {
                    IdTrinhDo = id,
                    TenTrinhDo = CommonHandler.ConvertToNullableString(edTenTrinhDo.EditValue),

                };
                _busTrinhDo.Put(id, obj);
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
            edTenTrinhDo.EditValue = grid.GetFocusedRowCellValue("TenTrinhDo").ToString();
        }
        #endregion

        #region Process
        private void LoadDataGrid()
        {
            var data = _busTrinhDo.GetAll();
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
                edTenTrinhDo.ReadOnly = true;
            }
            else if (_FormStatus == FormStatus.Create || _FormStatus == FormStatus.Edit)
            {
                edTenTrinhDo.ReadOnly = false;
            }
        }

        private void ClearEditControll()
        {
            edTenTrinhDo.EditValue = null;
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
    }
}