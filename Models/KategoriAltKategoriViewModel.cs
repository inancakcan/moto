using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moto.Models
{
    public class KategoriAltKategoriViewModel
    {
        public KategoriAltKategoriViewModel()
        {
            AvailableKategoris = new List<SelectListItem>();
            AvailableAltKategoris = new List<SelectListItem>();
        }

        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }
        public IList<SelectListItem> AvailableKategoris { get; set; }
        [Display(Name = "Model")]
        public int AltKategoriId { get; set; }
        public IList<SelectListItem> AvailableAltKategoris { get; set; }
    }
}