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
    public class OutfitNamesController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: OutfitNames
        public ActionResult Index()
        {
            var outfitNames = db.OutfitNames.Include(o => o.Charachter);
            return View(outfitNames.ToList());
        }

        // GET: OutfitNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutfitName outfitName = db.OutfitNames.Find(id);
            FullOutfit fullOutfit = new FullOutfit();
            fullOutfit.OutfitParts = (from c in db.OutfitParts where c.OutfitID==(id) select c).ToList();
            fullOutfit.Sheos = (from c in db.OutfitParts where c.OutfitID==(id) select c.Shoe).ToList();
            fullOutfit.Tops = (from c in db.OutfitParts where c.OutfitID==(id) select c.Top).ToList();
            fullOutfit.Accessories = (from c in db.OutfitParts where c.OutfitID==(id) select c.Accessory).ToList();
            fullOutfit.Bottoms = (from c in db.OutfitParts where c.OutfitID==(id) select c.Bottom).ToList();
            fullOutfit.Name = outfitName.Name;
            fullOutfit.Occasion = outfitName.Occasion;
            fullOutfit.Season = outfitName.Season;
            fullOutfit.Actor = outfitName.Charachter.Photo;
            //foreach (OutfitPart p in fullOutfit.OutfitParts)
            //{
            //    fullOutfit.Tops.Add((from c in db.Tops where c.OutfitParts.Equals(p) select c));
            //}
            if (outfitName == null)
            {
                return HttpNotFound();
            }
            return View(fullOutfit);
        }

        // GET: OutfitNames/Create
        public ActionResult Create()
        {
            ViewBag.CharchterID = new SelectList(db.Charachters, "CharachterID", "CharachterName");
            return View();
        }

        // POST: OutfitNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitID,Name,Season,Occasion,CharchterID")] OutfitName outfitName)
        {
            if (ModelState.IsValid)
            {
                db.OutfitNames.Add(outfitName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharchterID = new SelectList(db.Charachters, "CharachterID", "CharachterName", outfitName.CharchterID);
            return View(outfitName);
        }

        // GET: OutfitNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutfitName outfitName = db.OutfitNames.Find(id);
            if (outfitName == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharchterID = new SelectList(db.Charachters, "CharachterID", "CharachterName", outfitName.CharchterID);
            return View(outfitName);
        }

        // POST: OutfitNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitID,Name,Season,Occasion,CharchterID")] OutfitName outfitName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfitName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharchterID = new SelectList(db.Charachters, "CharachterID", "CharachterName", outfitName.CharchterID);
            return View(outfitName);
        }

        // GET: OutfitNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutfitName outfitName = db.OutfitNames.Find(id);
            if (outfitName == null)
            {
                return HttpNotFound();
            }
            return View(outfitName);
        }

        // POST: OutfitNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutfitName outfitName = db.OutfitNames.Find(id);
            db.OutfitNames.Remove(outfitName);
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
