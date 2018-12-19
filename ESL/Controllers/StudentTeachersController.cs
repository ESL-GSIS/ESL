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
    public class StudentTeachersController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: StudentTeachers
        public ActionResult Index()
        {
            var studentTeachers = db.StudentTeachers.Include(s => s.Student).Include(s => s.Teacher);
            return View(studentTeachers.ToList());
        }

        // GET: StudentTeachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTeacher studentTeacher = db.StudentTeachers.Find(id);
            if (studentTeacher == null)
            {
                return HttpNotFound();
            }
            return View(studentTeacher);
        }

        // GET: StudentTeachers/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName");
            return View();
        }

        // POST: StudentTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,TeacherID")] StudentTeacher studentTeacher)
        {
            if (ModelState.IsValid)
            {
                db.StudentTeachers.Add(studentTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentTeacher.StudentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName", studentTeacher.TeacherID);
            return View(studentTeacher);
        }

        // GET: StudentTeachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTeacher studentTeacher = db.StudentTeachers.Find(id);
            if (studentTeacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentTeacher.StudentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName", studentTeacher.TeacherID);
            return View(studentTeacher);
        }

        // POST: StudentTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,TeacherID")] StudentTeacher studentTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentTeacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentTeacher.StudentID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName", studentTeacher.TeacherID);
            return View(studentTeacher);
        }

        // GET: StudentTeachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentTeacher studentTeacher = db.StudentTeachers.Find(id);
            if (studentTeacher == null)
            {
                return HttpNotFound();
            }
            return View(studentTeacher);
        }

        // POST: StudentTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentTeacher studentTeacher = db.StudentTeachers.Find(id);
            db.StudentTeachers.Remove(studentTeacher);
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
