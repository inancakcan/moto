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
    public class semtsController : Controller
    {
        private motobulvarEntities db = new motobulvarEntities();

        // GET: semts
        public ActionResult Index()
        {
            var semt = db.semt.Include(s => s.ilce);
            return View(semt.ToList());
        }

        // GET: semts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semt semt = db.semt.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        // GET: semts/Create
        public ActionResult Create()
        {
            ViewBag.ilceID = new SelectList(db.ilce, "ilceID", "ad");
            return View();
        }

        // POST: semts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "semtID,ilceID,ad")] semt semt)
        {
            if (ModelState.IsValid)
            {
                db.semt.Add(semt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ilceID = new SelectList(db.ilce, "ilceID", "ad", semt.ilceID);
            return View(semt);
        }

        // GET: semts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semt semt = db.semt.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            ViewBag.ilceID = new SelectList(db.ilce, "ilceID", "ad", semt.ilceID);
            return View(semt);
        }

        // POST: semts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "semtID,ilceID,ad")] semt semt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(semt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ilceID = new SelectList(db.ilce, "ilceID", "ad", semt.ilceID);
            return View(semt);
        }

        // GET: semts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            semt semt = db.semt.Find(id);
            if (semt == null)
            {
                return HttpNotFound();
            }
            return View(semt);
        }

        // POST: semts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            semt semt = db.semt.Find(id);
            db.semt.Remove(semt);
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
