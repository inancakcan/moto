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
    
    public partial class mot_SilindirSayisi
    {
        public mot_SilindirSayisi()
        {
            this.mot_Motor = new HashSet<mot_Motor>();
        }
    
        public int Id { get; set; }
        public string SilindirSayisi { get; set; }
    
        public virtual ICollection<mot_Motor> mot_Motor { get; set; }
    }
}