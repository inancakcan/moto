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
    public class ilcesController : Controller
    {
        private motobulvarEntities db = new motobulvarEntities();

        // GET: ilces
        public ActionResult Index()
        {
            var ilce = db.ilce.Include(i => i.il);
            return View(ilce.ToList());
        }

        // GET: ilces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilce ilce = db.ilce.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // GET: ilces/Create
        public ActionResult Create()
        {
            ViewBag.ilID = new SelectList(db.il, "ilID", "ad");
            return View();
        }

        // POST: ilces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ilceID,ilID,ad")] ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.ilce.Add(ilce);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ilID = new SelectList(db.il, "ilID", "ad", ilce.ilID);
            return View(ilce);
        }

        // GET: ilces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilce ilce = db.ilce.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            ViewBag.ilID = new SelectList(db.il, "ilID", "ad", ilce.ilID);
            return View(ilce);
        }

        // POST: ilces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ilceID,ilID,ad")] ilce ilce)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ilce).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ilID = new SelectList(db.il, "ilID", "ad", ilce.ilID);
            return View(ilce);
        }

        // GET: ilces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ilce ilce = db.ilce.Find(id);
            if (ilce == null)
            {
                return HttpNotFound();
            }
            return View(ilce);
        }

        // POST: ilces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ilce ilce = db.ilce.Find(id);
            db.ilce.Remove(ilce);
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
