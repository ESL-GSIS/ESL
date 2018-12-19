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
    public class SchoolStudentsController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: SchoolStudents
        public ActionResult Index()
        {
            var schoolStudents = db.SchoolStudents.Include(s => s.School).Include(s => s.School1).Include(s => s.School2).Include(s => s.School3).Include(s => s.Student);
            return View(schoolStudents.ToList());
        }

        // GET: SchoolStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolStudent schoolStudent = db.SchoolStudents.Find(id);
            if (schoolStudent == null)
            {
                return HttpNotFound();
            }
            return View(schoolStudent);
        }

        // GET: SchoolStudents/Create
        public ActionResult Create()
        {
            ViewBag.CurrentSchool = new SelectList(db.Schools, "ID", "Name");
            ViewBag.PreviousSchool1 = new SelectList(db.Schools, "ID", "Name");
            ViewBag.PreviousSchool2 = new SelectList(db.Schools, "ID", "Name");
            ViewBag.PreviousSchool3 = new SelectList(db.Schools, "ID", "Name");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: SchoolStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,CurrentSchool,PreviousSchool1,PreviousSchool2,PreviousSchool3")] SchoolStudent schoolStudent)
        {
            if (ModelState.IsValid)
            {
                db.SchoolStudents.Add(schoolStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrentSchool = new SelectList(db.Schools, "ID", "Name", schoolStudent.CurrentSchool);
            ViewBag.PreviousSchool1 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool1);
            ViewBag.PreviousSchool2 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool2);
            ViewBag.PreviousSchool3 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool3);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", schoolStudent.StudentID);
            return View(schoolStudent);
        }

        // GET: SchoolStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolStudent schoolStudent = db.SchoolStudents.Find(id);
            if (schoolStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentSchool = new SelectList(db.Schools, "ID", "Name", schoolStudent.CurrentSchool);
            ViewBag.PreviousSchool1 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool1);
            ViewBag.PreviousSchool2 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool2);
            ViewBag.PreviousSchool3 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool3);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", schoolStudent.StudentID);
            return View(schoolStudent);
        }

        // POST: SchoolStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CurrentSchool,PreviousSchool1,PreviousSchool2,PreviousSchool3")] SchoolStudent schoolStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentSchool = new SelectList(db.Schools, "ID", "Name", schoolStudent.CurrentSchool);
            ViewBag.PreviousSchool1 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool1);
            ViewBag.PreviousSchool2 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool2);
            ViewBag.PreviousSchool3 = new SelectList(db.Schools, "ID", "Name", schoolStudent.PreviousSchool3);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", schoolStudent.StudentID);
            return View(schoolStudent);
        }

        // GET: SchoolStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SchoolStudent schoolStudent = db.SchoolStudents.Find(id);
            if (schoolStudent == null)
            {
                return HttpNotFound();
            }
            return View(schoolStudent);
        }

        // POST: SchoolStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SchoolStudent schoolStudent = db.SchoolStudents.Find(id);
            db.SchoolStudents.Remove(schoolStudent);
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
