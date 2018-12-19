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
    public class TeacherClassesController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: TeacherClasses
        public ActionResult Index()
        {
            var teacherClasses = db.TeacherClasses.Include(t => t.Class).Include(t => t.Teacher);
            return View(teacherClasses.ToList());
        }

        // GET: TeacherClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherClass teacherClass = db.TeacherClasses.Find(id);
            if (teacherClass == null)
            {
                return HttpNotFound();
            }
            return View(teacherClass);
        }

        // GET: TeacherClasses/Create
        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name");
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName");
            return View();
        }

        // POST: TeacherClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TeacherID,ClassID")] TeacherClass teacherClass)
        {
            if (ModelState.IsValid)
            {
                db.TeacherClasses.Add(teacherClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", teacherClass.ClassID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName", teacherClass.TeacherID);
            return View(teacherClass);
        }

        // GET: TeacherClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherClass teacherClass = db.TeacherClasses.Find(id);
            if (teacherClass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", teacherClass.ClassID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName", teacherClass.TeacherID);
            return View(teacherClass);
        }

        // POST: TeacherClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TeacherID,ClassID")] TeacherClass teacherClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(db.Classes, "ID", "Name", teacherClass.ClassID);
            ViewBag.TeacherID = new SelectList(db.Teachers, "ID", "LastName", teacherClass.TeacherID);
            return View(teacherClass);
        }

        // GET: TeacherClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherClass teacherClass = db.TeacherClasses.Find(id);
            if (teacherClass == null)
            {
                return HttpNotFound();
            }
            return View(teacherClass);
        }

        // POST: TeacherClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherClass teacherClass = db.TeacherClasses.Find(id);
            db.TeacherClasses.Remove(teacherClass);
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
