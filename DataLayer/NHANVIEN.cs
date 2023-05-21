//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.BAOHIEMs = new HashSet<BAOHIEM>();
            this.CONGTACs = new HashSet<CONGTAC>();
            this.HOPDONGs = new HashSet<HOPDONG>();
            this.KHENTHUONGKYLUATs = new HashSet<KHENTHUONGKYLUAT>();
            this.NHANVIEN_LUONG = new HashSet<NHANVIEN_LUONG>();
        }
    
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string CCCD { get; set; }
        public Nullable<double> HeSoLuong { get; set; }
        public byte[] HinhAnh { get; set; }
        public Nullable<int> IdPhongBan { get; set; }
        public Nullable<int> IdChucVu { get; set; }
        public Nullable<int> IdTrinhDo { get; set; }
        public Nullable<int> IdDanToc { get; set; }
        public Nullable<int> IdTonGiao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAOHIEM> BAOHIEMs { get; set; }
        public virtual CHUCVU CHUCVU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONGTAC> CONGTACs { get; set; }
        public virtual DANTOC DANTOC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHENTHUONGKYLUAT> KHENTHUONGKYLUATs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIEN_LUONG> NHANVIEN_LUONG { get; set; }
        public virtual PHONGBAN PHONGBAN { get; set; }
        public virtual TONGIAO TONGIAO { get; set; }
        public virtual TRINHDO TRINHDO { get; set; }
    }
}
