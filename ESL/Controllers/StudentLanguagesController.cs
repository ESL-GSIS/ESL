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
    public class StudentLanguagesController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: StudentLanguages
        public ActionResult Index()
        {
            var studentLanguages = db.StudentLanguages.Include(s => s.Language).Include(s => s.Language4).Include(s => s.Language5).Include(s => s.Student);
            return View(studentLanguages.ToList());
        }

        // GET: StudentLanguages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLanguage studentLanguage = db.StudentLanguages.Find(id);
            if (studentLanguage == null)
            {
                return HttpNotFound();
            }
            return View(studentLanguage);
        }

        // GET: StudentLanguages/Create
        public ActionResult Create()
        {
            ViewBag.Language1 = new SelectList(db.Languages, "ID", "Name");
            ViewBag.Language2 = new SelectList(db.Languages, "ID", "Name");
            ViewBag.Language3 = new SelectList(db.Languages, "ID", "Name");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: StudentLanguages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,Language1,Language2,Language3")] StudentLanguage studentLanguage)
        {
            if (ModelState.IsValid)
            {
                db.StudentLanguages.Add(studentLanguage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Language1 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language1);
            ViewBag.Language2 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language2);
            ViewBag.Language3 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language3);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentLanguage.StudentID);
            return View(studentLanguage);
        }

        // GET: StudentLanguages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLanguage studentLanguage = db.StudentLanguages.Find(id);
            if (studentLanguage == null)
            {
                return HttpNotFound();
            }
            ViewBag.Language1 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language1);
            ViewBag.Language2 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language2);
            ViewBag.Language3 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language3);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentLanguage.StudentID);
            return View(studentLanguage);
        }

        // POST: StudentLanguages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Language1,Language2,Language3")] StudentLanguage studentLanguage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLanguage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Language1 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language1);
            ViewBag.Language2 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language2);
            ViewBag.Language3 = new SelectList(db.Languages, "ID", "Name", studentLanguage.Language3);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentLanguage.StudentID);
            return View(studentLanguage);
        }

        // GET: StudentLanguages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLanguage studentLanguage = db.StudentLanguages.Find(id);
            if (studentLanguage == null)
            {
                return HttpNotFound();
            }
            return View(studentLanguage);
        }

        // POST: StudentLanguages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentLanguage studentLanguage = db.StudentLanguages.Find(id);
            db.StudentLanguages.Remove(studentLanguage);
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
