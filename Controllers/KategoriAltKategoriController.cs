using System;
using System.Web.Mvc;
using moto.App_Start;
using moto.Models;
using System.Collections.Generic;
using System.Linq;


namespace moto.Controllers
{
    public class KategoriAltKategoriController : Controller
    {
        // GET: KategoriAltKategori
        public ActionResult Index(int? IlanId)
        {
            if (IlanId != null)
            {
                Query q = new Query();
                ViewBag.AltKategoriId = q.IlanIddenAltKategoriIdDon(IlanId.Value);
                ViewBag.KategoriId = q.AltKategoriIddenKategoriIdDon(ViewBag.AltKategoriId);
            }

            KategoriAltKategoriViewModel model = new KategoriAltKategoriViewModel();
            //model.AvailableKategoris.Add(new SelectListItem { Text = "-Kategori seçiniz-", Value = "0" });
            model.AvailableKategoris.Add(new SelectListItem { Text = "-Kategori seçiniz-", Value = "0" });
            KategoriAltKategori iss = new KategoriAltKategori();
            var Kategoris = iss.GetAllKategoris();
            foreach (var kategori in Kategoris)
            {
                model.AvailableKategoris.Add(new SelectListItem() { Text = kategori.KategoriAdi, Value = kategori.KategoriId.ToString() });
            }

            if (ViewBag.KategoriId != null)
            {
                model.KategoriId = ViewBag.KategoriId;
                var altKategoris = iss.GetAllAltKategorisByKategoriId(model.KategoriId);
                foreach (var altKategori in altKategoris)
                {
                    model.AvailableAltKategoris.Add(new SelectListItem() { Text = altKategori.AltKategoriAdi, Value = altKategori.Id.ToString() });
                }
                model.AltKategoriId = ViewBag.AltKategoriId;
            }
            return View(model);
        }

        public IList<AltKategori> KategorininAltKategorileriniDon(int KategoriId)
        {
            KategoriAltKategori iss = new KategoriAltKategori();
            var altKategoris=iss.GetAllAltKategorisByKategoriId(KategoriId);
            return altKategoris;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAltKategorisByKategoriId(string KategoriId)
        {
            if (String.IsNullOrEmpty(KategoriId))
            {
                throw new ArgumentNullException("KategoriId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(KategoriId, out id);
            KategoriAltKategori iss = new KategoriAltKategori();
            using (motobulvarEntities ent = new motobulvarEntities())
            {
                var altKategoris = iss.GetAllAltKategorisByKategoriId(id);
                var result = (from i in altKategoris
                              select new
                              {
                                  id = i.Id,
                                  name = i.AltKategoriAdi
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


    }
}