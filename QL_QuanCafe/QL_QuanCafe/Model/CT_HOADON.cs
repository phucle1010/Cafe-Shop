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
    
    public partial class CT_HOADON
    {
        public int MaCTHD { get; set; }
        public Nullable<int> MaHD { get; set; }
        public Nullable<int> MaDM { get; set; }
    
        public virtual DATMON DATMON { get; set; }
        public virtual HOADON HOADON { get; set; }
    }
}
