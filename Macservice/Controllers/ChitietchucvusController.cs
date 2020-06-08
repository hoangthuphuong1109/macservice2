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
    public class ChitietchucvusController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chitietchucvus
        public ActionResult Index()
        {
            var chitietchucvus = db.Chitietchucvus.Include(c => c.Chucvu).Include(c => c.Thongtinnhansu);
            return View(chitietchucvus.ToList());
        }

        // GET: Chitietchucvus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            if (chitietchucvu == null)
            {
                return HttpNotFound();
            }
            return View(chitietchucvu);
        }

        // GET: Chitietchucvus/Create
        public ActionResult Create()
        {
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Chitietchucvus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietchucvu,Manv,Machucvu,Tungay,Denngay")] Chitietchucvu chitietchucvu)
        {
            if (ModelState.IsValid)
            {
                db.Chitietchucvus.Add(chitietchucvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", chitietchucvu.Machucvu);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietchucvu.Manv);
            return View(chitietchucvu);
        }

        // GET: Chitietchucvus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            if (chitietchucvu == null)
            {
                return HttpNotFound();
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", chitietchucvu.Machucvu);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietchucvu.Manv);
            return View(chitietchucvu);
        }

        // POST: Chitietchucvus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietchucvu,Manv,Machucvu,Tungay,Denngay")] Chitietchucvu chitietchucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietchucvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Machucvu = new SelectList(db.Chucvus, "Machucvu", "Tenchucvu", chitietchucvu.Machucvu);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietchucvu.Manv);
            return View(chitietchucvu);
        }

        // GET: Chitietchucvus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            if (chitietchucvu == null)
            {
                return HttpNotFound();
            }
            return View(chitietchucvu);
        }

        // POST: Chitietchucvus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietchucvu chitietchucvu = db.Chitietchucvus.Find(id);
            db.Chitietchucvus.Remove(chitietchucvu);
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
