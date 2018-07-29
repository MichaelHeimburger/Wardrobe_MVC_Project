using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC.Models;

namespace WardrobeMVC.Controllers
{
    public class CharachtersController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: Charachters
        public ActionResult Index()
        {
            return View(db.Charachters.ToList());
        }

        // GET: Charachters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charachter charachter = db.Charachters.Find(id);
            if (charachter == null)
            {
                return HttpNotFound();
            }
            return View(charachter);
        }

        // GET: Charachters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Charachters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharachterID,CharachterName,Photo")] Charachter charachter)
        {
            if (ModelState.IsValid)
            {
                db.Charachters.Add(charachter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(charachter);
        }

        // GET: Charachters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charachter charachter = db.Charachters.Find(id);
            if (charachter == null)
            {
                return HttpNotFound();
            }
            return View(charachter);
        }

        // POST: Charachters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharachterID,CharachterName,Photo")] Charachter charachter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charachter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charachter);
        }

        // GET: Charachters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Charachter charachter = db.Charachters.Find(id);
            if (charachter == null)
            {
                return HttpNotFound();
            }
            return View(charachter);
        }

        // POST: Charachters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Charachter charachter = db.Charachters.Find(id);
            db.Charachters.Remove(charachter);
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
