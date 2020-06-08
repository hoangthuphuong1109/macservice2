using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Macservice.Models;

namespace Macservice.Controllers
{
    public class ChitietkyluatsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chitietkyluats
        public ActionResult Index()
        {
            var chitietkyluats = db.Chitietkyluats.Include(c => c.Kyluat).Include(c => c.Thongtinnhansu);
            return View(chitietkyluats.ToList());
        }

        // GET: Chitietkyluats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            if (chitietkyluat == null)
            {
                return HttpNotFound();
            }
            return View(chitietkyluat);
        }

        // GET: Chitietkyluats/Create
        public ActionResult Create()
        {
            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Chitietkyluats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietkyluat,Manv,Makyluat,Lydokyluat,Tienphat")] Chitietkyluat chitietkyluat)
        {
            if (ModelState.IsValid)
            {
                db.Chitietkyluats.Add(chitietkyluat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat", chitietkyluat.Makyluat);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkyluat.Manv);
            return View(chitietkyluat);
        }

        // GET: Chitietkyluats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            if (chitietkyluat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat", chitietkyluat.Makyluat);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkyluat.Manv);
            return View(chitietkyluat);
        }

        // POST: Chitietkyluats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietkyluat,Manv,Makyluat,Lydokyluat,Tienphat")] Chitietkyluat chitietkyluat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietkyluat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Makyluat = new SelectList(db.Kyluats, "Makyluat", "Tenkyluat", chitietkyluat.Makyluat);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkyluat.Manv);
            return View(chitietkyluat);
        }

        // GET: Chitietkyluats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            if (chitietkyluat == null)
            {
                return HttpNotFound();
            }
            return View(chitietkyluat);
        }

        // POST: Chitietkyluats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietkyluat chitietkyluat = db.Chitietkyluats.Find(id);
            db.Chitietkyluats.Remove(chitietkyluat);
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
