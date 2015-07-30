using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using moto.Models;
using moto.App_Start;
namespace moto.Controllers
{
    public class IlanController : Controller
    {
        private motobulvarEntities db = new motobulvarEntities();

        // GET: Ilan
        public ActionResult Index()
        {
            return View(db.Ilan.ToList());
        }

        // GET: Ilan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // GET: Ilan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ilan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IlanId,IlanBasligi,ShortDescription,FullDescription,AnasayfadaGoster,Published,Active,Deleted,CreatedOn,UpdatedOn,IlanSahibi,Fiyati,Lat,Lon,IlanResimleri,Video,PostaKodu,IlanTarihi,GoruntulenmeSayisi,AltKategoriId")] Ilan ilan)
        {
            if (ModelState.IsValid)
            {
                db.Ilan.Add(ilan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilan);
        }

        // GET: Ilan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IlanId,IlanBasligi,ShortDescription,FullDescription,AnasayfadaGoster,Published,Active,Deleted,CreatedOn,UpdatedOn,IlanSahibi,Fiyati,Lat,Lon,IlanResimleri,Video,PostaKodu,IlanTarihi,GoruntulenmeSayisi,AltKategoriId")] Ilan ilan, string PostaKoduId)
        {
            if (ModelState.IsValid)
            {
                ilan.PostaKodu = PostaKoduId;
                ilan.AnasayfadaGoster = false;
                ilan.Published = false;
                ilan.Active = false;
                ilan.Deleted = false;
                ilan.CreatedOn = DateTime.Now;
                ilan.UpdatedOn = DateTime.Now;
                ilan.IlanSahibi = Guid.Parse("05d9de39-b810-49ee-a245-befa07f4c4de");
                ilan.IlanTarihi = DateTime.Today;
                db.Entry(ilan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilan);
        }

        // GET: Ilan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilan ilan = db.Ilan.Find(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }
            return View(ilan);
        }

        // POST: Ilan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ilan ilan = db.Ilan.Find(id);
            db.Ilan.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult MyPartialView()
        {
            return PartialView("MyPartialView");
        }


        public ActionResult motoE(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //mot_Motor mot_Motor = db.mot_Motor.Find(id);
            //if (mot_Motor == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.index = 0;
            ViewBag.IlanId = id;
            Query q = new Query();
            ViewBag.MotosikletId = q.IlanIddenMotosikletIdDon(id);
            return View();
        }

    }
}
