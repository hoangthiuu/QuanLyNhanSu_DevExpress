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
    
    public partial class CONGTAC
    {
        public int IdCongTac { get; set; }
        public Nullable<int> MaNV { get; set; }
        public Nullable<System.DateTime> TuNgay { get; set; }
        public Nullable<System.DateTime> DenNgay { get; set; }
        public string PhongBanCongTac { get; set; }
    
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
