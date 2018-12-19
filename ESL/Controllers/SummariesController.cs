using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ESL.Models;

namespace ESL.Controllers
{
    public class SummariesController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: Summaries
        public ActionResult Index()
        {
            var summaries = db.Summaries.Include(s => s.Quarter);
            return View(summaries.ToList());
        }

        // GET: Summaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // GET: Summaries/Create
        public ActionResult Create()
        {
            ViewBag.QuarterID = new SelectList(db.Quarters, "ID", "ID");
            return View();
        }

        // POST: Summaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Note,QuarterID")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                db.Summaries.Add(summary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuarterID = new SelectList(db.Quarters, "ID", "ID", summary.QuarterID);
            return View(summary);
        }

        // GET: Summaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuarterID = new SelectList(db.Quarters, "ID", "ID", summary.QuarterID);
            return View(summary);
        }

        // POST: Summaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Note,QuarterID")] Summary summary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(summary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuarterID = new SelectList(db.Quarters, "ID", "ID", summary.QuarterID);
            return View(summary);
        }

        // GET: Summaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Summary summary = db.Summaries.Find(id);
            if (summary == null)
            {
                return HttpNotFound();
            }
            return View(summary);
        }

        // POST: Summaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Summary summary = db.Summaries.Find(id);
            db.Summaries.Remove(summary);
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
