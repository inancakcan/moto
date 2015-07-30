using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moto.Models
{
    public class MotMarkaModelViewModel
    {
        public MotMarkaModelViewModel()
        {
            AvailableMotMarkas = new List<SelectListItem>();
            AvailableMotModels = new List<SelectListItem>();
            
        }
        [Display(Name = "Marka")]
        public int MotMarkaId { get; set; }
        public IList<SelectListItem> AvailableMotMarkas { get; set; }
        [Display(Name = "Model")]
        public int MotModelId { get; set; }
        public IList<SelectListItem> AvailableMotModels { get; set; }
    }
}