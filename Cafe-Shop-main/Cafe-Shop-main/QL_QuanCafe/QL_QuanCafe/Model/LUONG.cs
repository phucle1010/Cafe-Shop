//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_QuanCafe.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class LUONG
    {
        public string MaCaLV { get; set; }
        public string MaNV { get; set; }
        public Nullable<decimal> Luong1 { get; set; }
    
        public virtual CALAMVIEC CALAMVIEC { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}