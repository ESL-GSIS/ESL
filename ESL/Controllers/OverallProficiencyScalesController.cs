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
    public class OverallProficiencyScalesController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: OverallProficiencyScales
        public ActionResult Index()
        {
            var overallProficiencyScales = db.OverallProficiencyScales.Include(o => o.Student);
            return View(overallProficiencyScales.ToList());
        }

        // GET: OverallProficiencyScales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallProficiencyScale overallProficiencyScale = db.OverallProficiencyScales.Find(id);
            if (overallProficiencyScale == null)
            {
                return HttpNotFound();
            }
            return View(overallProficiencyScale);
        }

        // GET: OverallProficiencyScales/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: OverallProficiencyScales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Scale,Description,StudentID")] OverallProficiencyScale overallProficiencyScale)
        {
            if (ModelState.IsValid)
            {
                db.OverallProficiencyScales.Add(overallProficiencyScale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", overallProficiencyScale.StudentID);
            return View(overallProficiencyScale);
        }

        // GET: OverallProficiencyScales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallProficiencyScale overallProficiencyScale = db.OverallProficiencyScales.Find(id);
            if (overallProficiencyScale == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", overallProficiencyScale.StudentID);
            return View(overallProficiencyScale);
        }

        // POST: OverallProficiencyScales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Scale,Description,StudentID")] OverallProficiencyScale overallProficiencyScale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(overallProficiencyScale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", overallProficiencyScale.StudentID);
            return View(overallProficiencyScale);
        }

        // GET: OverallProficiencyScales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OverallProficiencyScale overallProficiencyScale = db.OverallProficiencyScales.Find(id);
            if (overallProficiencyScale == null)
            {
                return HttpNotFound();
            }
            return View(overallProficiencyScale);
        }

        // POST: OverallProficiencyScales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OverallProficiencyScale overallProficiencyScale = db.OverallProficiencyScales.Find(id);
            db.OverallProficiencyScales.Remove(overallProficiencyScale);
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
