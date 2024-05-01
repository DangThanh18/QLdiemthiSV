//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace de6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            this.DiemThis = new HashSet<DiemThi>();
        }
    
        [Key]
        public int MaSV { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string TenSV { get; set; }
        [Required]
        [Range(2000, 2006)]
        public Nullable<short> NamSinh { get; set; }
        [Required]
        public Nullable<bool> GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemThi> DiemThis { get; set; }
    }
}