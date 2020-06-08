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
    public class ChitietbaohiemsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chitietbaohiems
        public ActionResult Index()
        {
            var chitietbaohiems = db.Chitietbaohiems.Include(c => c.Baohiem).Include(c => c.Thongtinnhansu);
            return View(chitietbaohiems.ToList());
        }

        // GET: Chitietbaohiems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            if (chitietbaohiem == null)
            {
                return HttpNotFound();
            }
            return View(chitietbaohiem);
        }

        // GET: Chitietbaohiems/Create
        public ActionResult Create()
        {
            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Chitietbaohiems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietbaohiem,Mabaohiem,Manv,Tungay,Denngay")] Chitietbaohiem chitietbaohiem)
        {
            if (ModelState.IsValid)
            {
                db.Chitietbaohiems.Add(chitietbaohiem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem", chitietbaohiem.Mabaohiem);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbaohiem.Manv);
            return View(chitietbaohiem);
        }

        // GET: Chitietbaohiems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            if (chitietbaohiem == null)
            {
                return HttpNotFound();
            }
            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem", chitietbaohiem.Mabaohiem);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbaohiem.Manv);
            return View(chitietbaohiem);
        }

        // POST: Chitietbaohiems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietbaohiem,Mabaohiem,Manv,Tungay,Denngay")] Chitietbaohiem chitietbaohiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietbaohiem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Mabaohiem = new SelectList(db.Baohiems, "Mabaohiem", "Tenbaohiem", chitietbaohiem.Mabaohiem);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietbaohiem.Manv);
            return View(chitietbaohiem);
        }

        // GET: Chitietbaohiems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            if (chitietbaohiem == null)
            {
                return HttpNotFound();
            }
            return View(chitietbaohiem);
        }

        // POST: Chitietbaohiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietbaohiem chitietbaohiem = db.Chitietbaohiems.Find(id);
            db.Chitietbaohiems.Remove(chitietbaohiem);
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
