using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using moto.Models;
using moto.App_Start;

namespace moto.Controllers
{
    public class IlIlceController : Controller
    {
        // GET: IlIlce
        public ActionResult Index(int? IlanId)
        {
            if (IlanId != null)
            {
                Query q = new Query();
                ViewBag.IlanPostakutusuId = q.IlanIddenPostaKutusuIdDon(IlanId.Value);

                ObjectResult<sp_PKIlBaglantisi_Result> bak = q.pkIlBaglantisiniDon(ViewBag.IlanPostakutusuId);
                var bak2 = bak.First();
                ViewBag.IlanIlId = bak2.ilID;
                ViewBag.IlanIlceId = bak2.ilceID;
                ViewBag.IlanSemtId = bak2.semtID;
                ViewBag.IlanMahalleId = bak2.mahalleID;
                ViewBag.IlanPkId = bak2.pkID;
            }



            IlIlceViewModel model=new IlIlceViewModel();
            model.AvailableIls.Add(new SelectListItem{Text = "-İli seçiniz-",Value = "0"});
            IlceSemt iss  = new IlceSemt();
            var Ils = iss.GetAllIls();
            foreach (var Il in Ils)
            {
                model.AvailableIls.Add(new SelectListItem(){Text = Il.ad,Value = Il.ilID.ToString()});
            }

            if (ViewBag.IlanPostakutusuId != null)
            {
                //önce illeri doldur
                var Iller = iss.GetAllIls();
                foreach (var il in Iller)
                {
                    model.AvailableIls.Add(new SelectListItem() { Text = il.ad, Value = il.ilID.ToString() });
                }
                //ilçeleri doldur
                var Ilceler = iss.GetAllIlcesByIlId(ViewBag.IlanIlId);
                foreach (var oilce in Ilceler)
                {
                    model.AvailableIlces.Add(new SelectListItem() { Text = oilce.ad, Value = oilce.ilceID.ToString() });
                }

                //Semtleri doldur
                var Semtler = iss.GetAllSemtsByIlceId(ViewBag.IlanIlceId);
                foreach (var oSemt in Semtler)
                {
                    model.AvailableSemts.Add(new SelectListItem() { Text = oSemt.ad, Value = oSemt.semtID.ToString() });
                }

                //Mahalleleri doldur
                var Mahalleler = iss.GetAllMahallesByBySemtId(ViewBag.IlanSemtId);
                foreach (var oMahalleler in Mahalleler)
                {
                    model.AvailableMahalles.Add(new SelectListItem() { Text = oMahalleler.ad, Value = oMahalleler.mahalleID.ToString() });
                }

                //Mahalleleri doldur
                var PostaKodlari = iss.GetAllPostaKodsByByMahalleId(ViewBag.IlanMahalleId);
                foreach (var oPostaKodu in PostaKodlari)
                {
                    model.AvailablePostaKods.Add(new SelectListItem() { Text = oPostaKodu.kod.ToString(), Value = oPostaKodu.pkID.ToString()});
                }
                model.IlId = ViewBag.IlanIlId;
                model.IlceId = ViewBag.IlanIlceId;
                model.SemtId = ViewBag.IlanSemtId;
                model.MahalleId = ViewBag.IlanMahalleId;
                model.PostaKoduId = int.Parse(ViewBag.IlanPostakutusuId);

            }

            return View(model);
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetIlcesByIlId(string IlId)
        {
            if (String.IsNullOrEmpty(IlId))
            {
                throw new ArgumentNullException("IlId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(IlId, out id);
            IlceSemt iss = new IlceSemt();
            using (motobulvarEntities ent =new motobulvarEntities())
            {
            var ilces = iss.GetAllIlcesByIlId(id);
            var result = (from i in ilces
                          select new
                          {
                              id = i.ilceID,
                              name = i.ad
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);    
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSemtsByIlceId(string IlceId)
        {
            if (String.IsNullOrEmpty(IlceId))
            {
                throw new ArgumentNullException("IlceId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(IlceId, out id);
            IlceSemt iss = new IlceSemt();
            using (motobulvarEntities ent = new motobulvarEntities())
            {
                var semts = iss.GetAllSemtsByIlceId(id);
                var result = (from i in semts
                              select new
                              {
                                  id = i.semtID,
                                  name = i.ad
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetMahallesBySemtId(string SemtId)
        {
            if (String.IsNullOrEmpty(SemtId))
            {
                throw new ArgumentNullException("SemtId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SemtId, out id);
            IlceSemt iss = new IlceSemt();
            using (motobulvarEntities ent = new motobulvarEntities())
            {
                var mahalles = iss.GetAllMahallesByBySemtId(id);
                var result = (from i in mahalles
                              select new
                              {
                                  id = i.mahalleID,
                                  name = i.ad
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetPostaKodsByMahalleId(string MahalleId)
        {
            if (String.IsNullOrEmpty(MahalleId))
            {
                throw new ArgumentNullException("MahalleId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(MahalleId, out id);
            IlceSemt iss = new IlceSemt();
            using (motobulvarEntities ent = new motobulvarEntities())
            {
                var postakods = iss.GetAllPostaKodsByByMahalleId(id);
                var result = (from i in postakods
                              select new
                              {
                                  id = i.pkID,
                                  name = i.kod
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        } 


    }

}