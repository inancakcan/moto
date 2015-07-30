using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using moto.Models;

namespace moto.Controllers
{
    public class mahallesController : Controller
    {
        private motobulvarEntities db = new motobulvarEntities();

        // GET: mahalles
        public ActionResult Index()
        {
            var mahalle = db.mahalle.Include(m => m.semt);
            return View(mahalle.ToList());
        }

        // GET: mahalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mahalle mahalle = db.mahalle.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        // GET: mahalles/Create
        public ActionResult Create()
        {
            ViewBag.semtID = new SelectList(db.semt, "semtID", "ad");
            return View();
        }

        // POST: mahalles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mahalleID,semtID,ad")] mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                db.mahalle.Add(mahalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.semtID = new SelectList(db.semt, "semtID", "ad", mahalle.semtID);
            return View(mahalle);
        }

        // GET: mahalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mahalle mahalle = db.mahalle.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.semtID = new SelectList(db.semt, "semtID", "ad", mahalle.semtID);
            return View(mahalle);
        }

        // POST: mahalles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mahalleID,semtID,ad")] mahalle mahalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mahalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.semtID = new SelectList(db.semt, "semtID", "ad", mahalle.semtID);
            return View(mahalle);
        }

        // GET: mahalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mahalle mahalle = db.mahalle.Find(id);
            if (mahalle == null)
            {
                return HttpNotFound();
            }
            return View(mahalle);
        }

        // POST: mahalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mahalle mahalle = db.mahalle.Find(id);
            db.mahalle.Remove(mahalle);
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
    }
}
