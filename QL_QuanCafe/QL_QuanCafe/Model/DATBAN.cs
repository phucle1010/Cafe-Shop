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
    
    public partial class DATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATBAN()
        {
            this.DATMONs = new HashSet<DATMON>();
        }
    
        public string MaDatBan { get; set; }
        public string MaBan { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        public virtual BAN BAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATMON> DATMONs { get; set; }
    }
}