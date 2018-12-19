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
    public class LangProficiencyLevelsController : Controller
    {
        private ESLEntities db = new ESLEntities();

        // GET: LangProficiencyLevels
        public ActionResult Index()
        {
            var langProficiencyLevels = db.LangProficiencyLevels.Include(l => l.Domain);
            return View(langProficiencyLevels.ToList());
        }

        // GET: LangProficiencyLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LangProficiencyLevel langProficiencyLevel = db.LangProficiencyLevels.Find(id);
            if (langProficiencyLevel == null)
            {
                return HttpNotFound();
            }
            return View(langProficiencyLevel);
        }

        // GET: LangProficiencyLevels/Create
        public ActionResult Create()
        {
            ViewBag.DomainID = new SelectList(db.Domains, "ID", "Name");
            return View();
        }

        // POST: LangProficiencyLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Level,DomainID")] LangProficiencyLevel langProficiencyLevel)
        {
            if (ModelState.IsValid)
            {
                db.LangProficiencyLevels.Add(langProficiencyLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DomainID = new SelectList(db.Domains, "ID", "Name", langProficiencyLevel.DomainID);
            return View(langProficiencyLevel);
        }

        // GET: LangProficiencyLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LangProficiencyLevel langProficiencyLevel = db.LangProficiencyLevels.Find(id);
            if (langProficiencyLevel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DomainID = new SelectList(db.Domains, "ID", "Name", langProficiencyLevel.DomainID);
            return View(langProficiencyLevel);
        }

        // POST: LangProficiencyLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Level,DomainID")] LangProficiencyLevel langProficiencyLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(langProficiencyLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DomainID = new SelectList(db.Domains, "ID", "Name", langProficiencyLevel.DomainID);
            return View(langProficiencyLevel);
        }

        // GET: LangProficiencyLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LangProficiencyLevel langProficiencyLevel = db.LangProficiencyLevels.Find(id);
            if (langProficiencyLevel == null)
            {
                return HttpNotFound();
            }
            return View(langProficiencyLevel);
        }

        // POST: LangProficiencyLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LangProficiencyLevel langProficiencyLevel = db.LangProficiencyLevels.Find(id);
            db.LangProficiencyLevels.Remove(langProficiencyLevel);
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
