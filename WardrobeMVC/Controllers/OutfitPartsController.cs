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
    public class OutfitPartsController : Controller
    {
        private WardrobeMVCEntities db = new WardrobeMVCEntities();

        // GET: OutfitParts
        public ActionResult Index()
        {
            var outfitParts = db.OutfitParts.Include(o => o.Accessory).Include(o => o.Bottom).Include(o => o.OutfitName).Include(o => o.Shoe).Include(o => o.Top);
            return View(outfitParts.ToList());
        }

        // GET: OutfitParts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutfitPart outfitPart = db.OutfitParts.Find(id);
            if (outfitPart == null)
            {
                return HttpNotFound();
            }
            return View(outfitPart);
        }

        // GET: OutfitParts/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "ItemName");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "ItemName");
            ViewBag.OutfitID = new SelectList(db.OutfitNames, "OutfitID", "Name");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ItemName");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "ItemName");
            return View();
        }

        // POST: OutfitParts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OutfitPartID,TopID,BottomID,ShoeID,AccessoryID,OutfitID")] OutfitPart outfitPart)
        {
            if (ModelState.IsValid)
            {
                db.OutfitParts.Add(outfitPart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "ItemName", outfitPart.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "ItemName", outfitPart.BottomID);
            ViewBag.OutfitID = new SelectList(db.OutfitNames, "OutfitID", "Name", outfitPart.OutfitID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ItemName", outfitPart.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "ItemName", outfitPart.TopID);
            return View(outfitPart);
        }

        // GET: OutfitParts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutfitPart outfitPart = db.OutfitParts.Find(id);
            if (outfitPart == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "ItemName", outfitPart.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "ItemName", outfitPart.BottomID);
            ViewBag.OutfitID = new SelectList(db.OutfitNames, "OutfitID", "Name", outfitPart.OutfitID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ItemName", outfitPart.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "ItemName", outfitPart.TopID);
            return View(outfitPart);
        }

        // POST: OutfitParts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OutfitPartID,TopID,BottomID,ShoeID,AccessoryID,OutfitID")] OutfitPart outfitPart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outfitPart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "ItemName", outfitPart.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "ItemName", outfitPart.BottomID);
            ViewBag.OutfitID = new SelectList(db.OutfitNames, "OutfitID", "Name", outfitPart.OutfitID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "ItemName", outfitPart.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "ItemName", outfitPart.TopID);
            return View(outfitPart);
        }

        // GET: OutfitParts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutfitPart outfitPart = db.OutfitParts.Find(id);
            if (outfitPart == null)
            {
                return HttpNotFound();
            }
            return View(outfitPart);
        }

        // POST: OutfitParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutfitPart outfitPart = db.OutfitParts.Find(id);
            db.OutfitParts.Remove(outfitPart);
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
