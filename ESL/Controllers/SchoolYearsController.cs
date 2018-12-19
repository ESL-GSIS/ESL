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
    public class SchoolYearsController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: SchoolYears
        public ActionResult Index()
        {
            var schoolYears = db.SchoolYears.Include(s => s.Student);
            return View(schoolYears.ToList());
        }

        // GET: SchoolYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolYear schoolYear = db.SchoolYears.Find(id);
            if (schoolYear == null)
            {
                return HttpNotFound();
            }
            return View(schoolYear);
        }

        // GET: SchoolYears/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: SchoolYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,StudentID")] SchoolYear schoolYear)
        {
            if (ModelState.IsValid)
            {
                db.SchoolYears.Add(schoolYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", schoolYear.StudentID);
            return View(schoolYear);
        }

        // GET: SchoolYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolYear schoolYear = db.SchoolYears.Find(id);
            if (schoolYear == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", schoolYear.StudentID);
            return View(schoolYear);
        }

        // POST: SchoolYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,StudentID")] SchoolYear schoolYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", schoolYear.StudentID);
            return View(schoolYear);
        }

        // GET: SchoolYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolYear schoolYear = db.SchoolYears.Find(id);
            if (schoolYear == null)
            {
                return HttpNotFound();
            }
            return View(schoolYear);
        }

        // POST: SchoolYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolYear schoolYear = db.SchoolYears.Find(id);
            db.SchoolYears.Remove(schoolYear);
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
