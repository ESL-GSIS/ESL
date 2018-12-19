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
    public class StudentAdvisorsController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: StudentAdvisors
        public ActionResult Index()
        {
            var studentAdvisors = db.StudentAdvisors.Include(s => s.Advisor).Include(s => s.Student);
            return View(studentAdvisors.ToList());
        }

        // GET: StudentAdvisors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAdvisor studentAdvisor = db.StudentAdvisors.Find(id);
            if (studentAdvisor == null)
            {
                return HttpNotFound();
            }
            return View(studentAdvisor);
        }

        // GET: StudentAdvisors/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorID = new SelectList(db.Advisors, "ID", "LastName");
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: StudentAdvisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,AdvisorID")] StudentAdvisor studentAdvisor)
        {
            if (ModelState.IsValid)
            {
                db.StudentAdvisors.Add(studentAdvisor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorID = new SelectList(db.Advisors, "ID", "LastName", studentAdvisor.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentAdvisor.StudentID);
            return View(studentAdvisor);
        }

        // GET: StudentAdvisors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAdvisor studentAdvisor = db.StudentAdvisors.Find(id);
            if (studentAdvisor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "ID", "LastName", studentAdvisor.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentAdvisor.StudentID);
            return View(studentAdvisor);
        }

        // POST: StudentAdvisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,AdvisorID")] StudentAdvisor studentAdvisor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAdvisor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "ID", "LastName", studentAdvisor.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", studentAdvisor.StudentID);
            return View(studentAdvisor);
        }

        // GET: StudentAdvisors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAdvisor studentAdvisor = db.StudentAdvisors.Find(id);
            if (studentAdvisor == null)
            {
                return HttpNotFound();
            }
            return View(studentAdvisor);
        }

        // POST: StudentAdvisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAdvisor studentAdvisor = db.StudentAdvisors.Find(id);
            db.StudentAdvisors.Remove(studentAdvisor);
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
