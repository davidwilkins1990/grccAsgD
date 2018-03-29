using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsgD2._2.Models;

namespace AsgD2._2.Controllers
{
    public class CitationsController : Controller
    {
        private CitationsEntities db = new CitationsEntities();

        // GET: Citations
        public ActionResult Index()
        {
            return View(db.Citations.ToList());
        }

        // GET: Citations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citation citation = db.Citations.Find(id);
            if (citation == null)
            {
                return HttpNotFound();
            }
            return View(citation);
        }

        // GET: Citations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Citations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CitationNumber,PlateNumber,BadgeNumber,Date,Fee,Description")] Citation citation)
        {
            if (ModelState.IsValid)
            {
                db.Citations.Add(citation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(citation);
        }

        // GET: Citations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citation citation = db.Citations.Find(id);
            if (citation == null)
            {
                return HttpNotFound();
            }
            return View(citation);
        }

        // POST: Citations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CitationNumber,PlateNumber,BadgeNumber,Date,Fee,Description")] Citation citation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(citation);
        }

        // GET: Citations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Citation citation = db.Citations.Find(id);
            if (citation == null)
            {
                return HttpNotFound();
            }
            return View(citation);
        }

        // POST: Citations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Citation citation = db.Citations.Find(id);
            db.Citations.Remove(citation);
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
