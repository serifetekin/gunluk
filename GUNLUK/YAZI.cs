//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUNLUK
{
    using System;
    using System.Collections.Generic;
    
    public partial class YAZI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public YAZI()
        {
            this.YORUMs = new HashSet<YORUM>();
        }
    
        public int YAZI_REFNO { get; set; }
        public string BASLIK { get; set; }
        public string ICERIK { get; set; }
        public System.DateTime TARIH { get; set; }
        public bool DURUMU { get; set; }
        public int KATEGORI_REFNO { get; set; }
        public int TIKLANMA_SAYISI { get; set; }
        public string OZET { get; set; }
        public string RESIM { get; set; }
    
        public virtual KATEGORI KATEGORI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YORUM> YORUMs { get; set; }
    }
}
