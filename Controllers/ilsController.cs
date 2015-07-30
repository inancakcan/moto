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
    public class ilsController : Controller
    {
        private motobulvarEntities db = new motobulvarEntities();

        // GET: ils
        public ActionResult Index()
        {
            return View(db.il.ToList());
        }

        // GET: ils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            il il = db.il.Find(id);
            if (il == null)
            {
                return HttpNotFound();
            }
            return View(il);
        }

        // GET: ils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ilID,ad")] il il)
        {
            if (ModelState.IsValid)
            {
                db.il.Add(il);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(il);
        }

        // GET: ils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            il il = db.il.Find(id);
            if (il == null)
            {
                return HttpNotFound();
            }
            return View(il);
        }

        // POST: ils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ilID,ad")] il il)
        {
            if (ModelState.IsValid)
            {
                db.Entry(il).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(il);
        }

        // GET: ils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            il il = db.il.Find(id);
            if (il == null)
            {
                return HttpNotFound();
            }
            return View(il);
        }

        // POST: ils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            il il = db.il.Find(id);
            db.il.Remove(il);
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
