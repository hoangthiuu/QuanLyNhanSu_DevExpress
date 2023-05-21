using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QLNS.CommonVariables;

namespace QLNS
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        // Khai báo các biến toàn cục, dung cho trong form
        // Đưa tất cả các biến toàn cục lên đầu, khởi tạo giá trị của chúng trong Constructor
        #region Variables 
        NHANVIENBUS _busNhanVien;
        PHONGBANBUS _busPhongBan;
        CHUCVUBUS _busChucVu;
        TRINHDOBUS _busTrinhDo;
        DANTOCBUS _busDanToc;
        TONGIAOBUS _busTonGiao;
        FormStatus _status;
        Image _defaultImage;
        #endregion

        // Khởi tạo
        #region Constructor
        public frmNhanVien()
        {
            _status = FormStatus.View;
            _busNhanVien = new NHANVIENBUS();
            _busPhongBan = new PHONGBANBUS();
            _busChucVu = new CHUCVUBUS();
            _busTrinhDo = new TRINHDOBUS();
            _busDanToc = new DANTOCBUS();
            _busTonGiao = new TONGIAOBUS();
            InitializeComponent();
        }
        #endregion

        #region EventHandler
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            _defaultImage = pictureNhanVien.Image;
            gridView1.OptionsBehavior.Editable = false;// khóa lưới không cho sửa trục tiếp trên lưới
            ConfigButtonManager();
            LoadDataRepo();
            LoadDataGrid();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)    // THÊM
        {
            _status = FormStatus.Create;
            ConfigButtonManager();
            ClearEditControll();
        }
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)   // SỬA 
        {
            _status = FormStatus.Edit;
            ConfigButtonManager();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)   // XÓA 
        {
            if (XtraMessageBox.Show("Có chắc chắn xoá?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaNV"));
                _busNhanVien.Delete(id);
                LoadDataGrid();
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)    //LƯU 
        {
            if (_status == FormStatus.Create)
            {
                if (edHoTen.EditValue == null || edCCCD.EditValue == null)
                {
                    XtraMessageBox.Show("\"Họ tên\" và \"CCCD\" bắt buộc nhập!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var obj = new NHANVIEN
                {
                    HoTen = CommonHandler.ConvertToNullableString(edHoTen.EditValue),
                    GioiTinh = CommonHandler.ConvertToNullableString(edGioiTinh.EditValue),
                    NgaySinh = CommonHandler.ConvertToNullableDateTime(edNgaySinh.EditValue),
                    DiaChi = CommonHandler.ConvertToNullableString(edDiaChi.EditValue),
                    DienThoai = CommonHandler.ConvertToNullableString(edDienThoai.EditValue),
                    CCCD = CommonHandler.ConvertToNullableString(edCCCD.EditValue),
                    HeSoLuong = CommonHandler.ConvertToNullableDouble(edHeSoLuong.EditValue),
                    IdPhongBan = CommonHandler.ConvertToNullabeInt(edPhongBan.EditValue),
                    IdChucVu = CommonHandler.ConvertToNullabeInt(edChucVu.EditValue),
                    IdTrinhDo = CommonHandler.ConvertToNullabeInt(edTrinhDo.EditValue),
                    IdDanToc = CommonHandler.ConvertToNullabeInt(edDanToc.EditValue),
                    IdTonGiao = CommonHandler.ConvertToNullabeInt(edTonGiao.EditValue),
                    HinhAnh = ImageToBase64(pictureNhanVien.Image, ImageFormat.Png),
                };

                _busNhanVien.Post(obj);
            }
            else if (_status == FormStatus.Edit)
            {
                var id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MaNV"));
                var obj = new NHANVIEN
                {
                    MaNV = id,
                    HoTen = CommonHandler.ConvertToNullableString(edHoTen.EditValue),
                    GioiTinh = CommonHandler.ConvertToNullableString(edGioiTinh.EditValue),
                    NgaySinh = CommonHandler.ConvertToNullableDateTime(edNgaySinh.EditValue),
                    DiaChi = CommonHandler.ConvertToNullableString(edDiaChi.EditValue),
                    DienThoai = CommonHandler.ConvertToNullableString(edDienThoai.EditValue),
                    CCCD = CommonHandler.ConvertToNullableString(edCCCD.EditValue),
                    HeSoLuong = CommonHandler.ConvertToNullableDouble(edHeSoLuong.EditValue),
                    IdPhongBan = CommonHandler.ConvertToNullabeInt(edPhongBan.EditValue),
                    IdChucVu = CommonHandler.ConvertToNullabeInt(edChucVu.EditValue),
                    IdTrinhDo = CommonHandler.ConvertToNullabeInt(edTrinhDo.EditValue),
                    IdDanToc = CommonHandler.ConvertToNullabeInt(edDanToc.EditValue),
                    IdTonGiao = CommonHandler.ConvertToNullabeInt(edTonGiao.EditValue),
                    HinhAnh = ImageToBase64(pictureNhanVien.Image, ImageFormat.Png),
                };
                _busNhanVien.Put(id, obj);
            }

            LoadDataGrid();
            _status = FormStatus.View;
            ConfigButtonManager();
        }
        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _status = FormStatus.View;
            ConfigButtonManager();
        } //    HỦY 
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)   //    ĐÓNG
        {
            this.Close();
        }

        /// Khi focus vào 1 dòng --> Lấy thông tin các cột tương ứng bắn lên các editControl tương ứng bên trên
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var grid = sender as GridView;
            edHoTen.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("HoTen"));
            edGioiTinh.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("GioiTinh"));
            edNgaySinh.EditValue = CommonHandler.ConvertToNullableDateTime(grid.GetFocusedRowCellValue("NgaySinh"));
            edDiaChi.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("DiaChi"));
            edDienThoai.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("DienThoai"));
            edCCCD.EditValue = CommonHandler.ConvertToNullableString(grid.GetFocusedRowCellValue("CCCD"));
            edHeSoLuong.EditValue = CommonHandler.ConvertToNullableDouble(grid.GetFocusedRowCellValue("HeSoLuong"));
            edPhongBan.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("IdPhongBan"));
            edChucVu.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("IdChucVu"));
            edTrinhDo.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("IdTrinhDo"));
            edDanToc.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("IdDanToc"));
            edTonGiao.EditValue = CommonHandler.ConvertToNullabeInt(grid.GetFocusedRowCellValue("IdTonGiao"));
            var hinhAnh = grid.GetFocusedRowCellValue("HinhAnh");
            if (hinhAnh != null)
                pictureNhanVien.Image = Base64ToImage((byte[])hinhAnh);
            else
                pictureNhanVien.Image = _defaultImage;
        }
        #endregion

        #region Process

        // Chứa các trường chọn repo
        private void LoadDataRepo()
        {
            var dataPhongBan = _busPhongBan.GetAll();
            var dataTrinhDo = _busTrinhDo.GetAll();
            var dataDanToc = _busDanToc.GetAll();
            var dataTonGiao = _busTonGiao.GetAll();
            var dataChucVu = _busChucVu.GetAll();
            // load dl vào trường chọn 
            CommonHandler.LoadFromObject(edPhongBan, dataPhongBan, "IdPhongBan", "TenPhongBan");
            CommonHandler.LoadFromObject(edTrinhDo, dataTrinhDo, "IdTrinhDo", "TenTrinhDo");
            CommonHandler.LoadFromObject(edDanToc, dataDanToc, "IdDanToc", "TenDanToc");
            CommonHandler.LoadFromObject(edTonGiao, dataTonGiao, "IdTonGiao", "TenTonGiao");
            CommonHandler.LoadFromObject(edChucVu, dataChucVu, "IdChucVu", "TenChucVu");
            // load dl vào lưới hiển thị
            CommonHandler.LoadFromObject(repoPhongBan, dataPhongBan, "IdPhongBan", "TenPhongBan");
            CommonHandler.LoadFromObject(repoTrinhDo, dataTrinhDo, "IdTrinhDo", "TenTrinhDo");
            CommonHandler.LoadFromObject(repoDanToc, dataDanToc, "IdDanToc", "TenDanToc");
            CommonHandler.LoadFromObject(repoTonGiao, dataTonGiao, "IdTonGiao", "TenTonGiao");
            CommonHandler.LoadFromObject(repoChucVu, dataChucVu, "IdChucVu", "TenChucVu");
        }

        private void LoadDataGrid()
        {
            var data = _busNhanVien.GetAll();
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
                edHoTen.ReadOnly = true;
                edGioiTinh.ReadOnly = true;
                edNgaySinh.ReadOnly = true;
                edPhongBan.ReadOnly = true;
                edTonGiao.ReadOnly = true;
                edTrinhDo.ReadOnly = true;
                edDienThoai.ReadOnly = true;
                edDiaChi.ReadOnly = true;
                edCCCD.ReadOnly = true;
                edChucVu.ReadOnly = true;
                edDanToc.ReadOnly = true;
                edGioiTinh.ReadOnly = true;
            }
            else if (_status == FormStatus.Create || _status == FormStatus.Edit)
            {
                edHoTen.ReadOnly = false;
                edGioiTinh.ReadOnly = false;
                edNgaySinh.ReadOnly = false;
                edPhongBan.ReadOnly = false;
                edTonGiao.ReadOnly = false;
                edTrinhDo.ReadOnly = false;
                edDienThoai.ReadOnly = false;
                edDiaChi.ReadOnly = false;
                edCCCD.ReadOnly = false;
                edChucVu.ReadOnly = false;
                edDanToc.ReadOnly = false;
                edGioiTinh.ReadOnly = false;
            }
        }

        private void ClearEditControll()
        {
            edHoTen.EditValue = null;
            edGioiTinh.EditValue = null;
            edNgaySinh.EditValue = null;
            edPhongBan.EditValue = null;
            edTonGiao.EditValue = null;
            edTrinhDo.EditValue = null;
            edDienThoai.EditValue = null;
            edDiaChi.EditValue = null;
            edCCCD.EditValue = null;
            edChucVu.EditValue = null;
            
            edDanToc.EditValue = null;
            edGioiTinh.EditValue = null;
            pictureNhanVien.Image = _defaultImage;
        } // Thao tác chọn nút HỦY: tất cả các trạng thái chuyển về giá trị null
        #endregion


        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg)|*.png;*.jpg";
            openFile.Title = "Chọn hình ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureNhanVien.Image = Image.FromFile(openFile.FileName);
                pictureNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}