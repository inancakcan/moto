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
    
    public partial class mot_Motor
    {
        public mot_Motor()
        {
            this.mot_Guvenlik = new HashSet<mot_Guvenlik>();
        }
    
        public int Id { get; set; }
        public int Model { get; set; }
        public decimal Bedel { get; set; }
        public int Tip { get; set; }
        public int UretimYili { get; set; }
        public int Km { get; set; }
        public int MotorHacmi { get; set; }
        public int MotorGucu { get; set; }
        public int SilindirSayisi { get; set; }
        public int Vites { get; set; }
        public int Renk { get; set; }
        public int Kimden { get; set; }
        public bool Takasli { get; set; }
        public int Durumu { get; set; }
        public bool ABSCBS { get; set; }
        public bool Airbag { get; set; }
        public bool Alarm { get; set; }
        public bool Sirtlik { get; set; }
        public bool YanKorumaCubuklari { get; set; }
        public bool OnKorumaCubuklari { get; set; }
        public bool DusmeTopuzlari { get; set; }
        public bool ArkaBagaj { get; set; }
        public bool GPS { get; set; }
        public bool IsitmaliElcik { get; set; }
        public bool Egzoz { get; set; }
        public bool KoltukAltiBagaj { get; set; }
        public bool LedSinyal { get; set; }
        public bool LedStop { get; set; }
        public bool MuzikSistemi { get; set; }
        public bool XenonFar { get; set; }
        public bool Canta { get; set; }
        public bool CiftAyak { get; set; }
        public int IlanId { get; set; }
    
        public virtual mot_Durumu mot_Durumu { get; set; }
        public virtual ICollection<mot_Guvenlik> mot_Guvenlik { get; set; }
        public virtual mot_Kimden mot_Kimden { get; set; }
        public virtual mot_Model mot_Model { get; set; }
        public virtual mot_MotorGucu mot_MotorGucu { get; set; }
        public virtual mot_MotorHacmi mot_MotorHacmi { get; set; }
        public virtual mot_Renk mot_Renk { get; set; }
        public virtual mot_SilindirSayisi mot_SilindirSayisi { get; set; }
        public virtual mot_Tipi mot_Tipi { get; set; }
        public virtual mot_Vites mot_Vites { get; set; }
    }
}
