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
    public class StudentCounselorsController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: StudentCounselors
        public ActionResult Index()
        {
            var studentCounselors = db.StudentCounselors.Include(s => s.Counselor).Include(s => s.Student);
            return View(studentCounselors.ToList());
        }

        // GET: StudentCounselors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCounselor studentCounselor = db.StudentCounselors.Find(id);
            if (studentCounselor == null)
            {
                return HttpNotFound();
            }
            return View(studentCounselor);
        }

        // GET: StudentCounselors/Create
        public ActionResult Create()
        {
            ViewBag.CounselorID = new SelectList(db.Counselors, "ID", "LastName");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: StudentCounselors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,CounselorID")] StudentCounselor studentCounselor)
        {
            if (ModelState.IsValid)
            {
                db.StudentCounselors.Add(studentCounselor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CounselorID = new SelectList(db.Counselors, "ID", "LastName", studentCounselor.CounselorID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentCounselor.StudentID);
            return View(studentCounselor);
        }

        // GET: StudentCounselors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCounselor studentCounselor = db.StudentCounselors.Find(id);
            if (studentCounselor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CounselorID = new SelectList(db.Counselors, "ID", "LastName", studentCounselor.CounselorID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentCounselor.StudentID);
            return View(studentCounselor);
        }

        // POST: StudentCounselors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,CounselorID")] StudentCounselor studentCounselor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCounselor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CounselorID = new SelectList(db.Counselors, "ID", "LastName", studentCounselor.CounselorID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentCounselor.StudentID);
            return View(studentCounselor);
        }

        // GET: StudentCounselors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCounselor studentCounselor = db.StudentCounselors.Find(id);
            if (studentCounselor == null)
            {
                return HttpNotFound();
            }
            return View(studentCounselor);
        }

        // POST: StudentCounselors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCounselor studentCounselor = db.StudentCounselors.Find(id);
            db.StudentCounselors.Remove(studentCounselor);
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
