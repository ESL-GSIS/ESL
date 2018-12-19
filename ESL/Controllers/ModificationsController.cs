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
    public class ModificationsController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: Modifications
        public ActionResult Index()
        {
            var modifications = db.Modifications.Include(m => m.Student);
            return View(modifications.ToList());
        }

        // GET: Modifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modification modification = db.Modifications.Find(id);
            if (modification == null)
            {
                return HttpNotFound();
            }
            return View(modification);
        }

        // GET: Modifications/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName");
            return View();
        }

        // POST: Modifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Instruction,Assignment,Assessment,StudentID")] Modification modification)
        {
            if (ModelState.IsValid)
            {
                db.Modifications.Add(modification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", modification.StudentID);
            return View(modification);
        }

        // GET: Modifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modification modification = db.Modifications.Find(id);
            if (modification == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", modification.StudentID);
            return View(modification);
        }

        // POST: Modifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Instruction,Assignment,Assessment,StudentID")] Modification modification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "LastName", modification.StudentID);
            return View(modification);
        }

        // GET: Modifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modification modification = db.Modifications.Find(id);
            if (modification == null)
            {
                return HttpNotFound();
            }
            return View(modification);
        }

        // POST: Modifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modification modification = db.Modifications.Find(id);
            db.Modifications.Remove(modification);
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
