//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace moto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kategori
    {
        public Kategori()
        {
            this.AltKategori = new HashSet<AltKategori>();
        }
    
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
    
        public virtual ICollection<AltKategori> AltKategori { get; set; }
    }
}
