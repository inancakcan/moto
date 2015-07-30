using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moto.Models
{
    public class IlIlceViewModel
    {
         public IlIlceViewModel()
        {
            AvailableIls = new List<SelectListItem>();
            AvailableIlces = new List<SelectListItem>();
            AvailableSemts = new List<SelectListItem>();
            AvailableMahalles = new List<SelectListItem>();
            AvailablePostaKods = new List<SelectListItem>();
            
        }
        [Display(Name="İl")]
         public int IlId { get; set; }
         public IList<SelectListItem> AvailableIls { get; set; }
        [Display(Name = "İlçe")]
         public int IlceId { get; set; }
         public IList<SelectListItem> AvailableIlces { get; set; }
        [Display(Name = "Semt")]
         public int SemtId { get; set; }
         public IList<SelectListItem> AvailableSemts { get; set; }
        [Display(Name = "Mahalle/Köy")]
         public int MahalleId { get; set; }
         public IList<SelectListItem> AvailableMahalles { get; set; }

         [Display(Name = "Posta Kodu")]
         public int PostaKoduId { get; set; }
         public IList<SelectListItem> AvailablePostaKods { get; set; }
    }
}