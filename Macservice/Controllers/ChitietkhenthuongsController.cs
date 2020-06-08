using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System;
using System.Web.Mvc;
using Macservice.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;


namespace Macservice.Controllers
{
    public class ChitietkhenthuongsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Chitietkhenthuongs
        public ActionResult Index(string tukhoa, int? maKhenthuong)
        {
            ViewBag.Tukhoa = tukhoa;
            ViewBag.Makhenthuong = maKhenthuong;
            if (tukhoa != null)
            {
                tukhoa = tukhoa.ToLower();
                tukhoa = tukhoa.Replace("ctkt", "").Replace("0", "");
            }
            var Chitietkhenthuong = db.Chitietkhenthuongs
           .Where(m => tukhoa == null || tukhoa.Trim() == "" || m.Lydokhenthuong.Contains(tukhoa) || m.Machitietkhenthuong.ToString() == tukhoa || m.Manv.ToString() == tukhoa)
           .Where(m => maKhenthuong == null || maKhenthuong == 0 || m.Makhenthuong == maKhenthuong)
           .Include(n => n.Khenthuong);

            return View(Chitietkhenthuong.ToList());
        }

        // GET: Chitietkhenthuongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(chitietkhenthuong);
        }

        // GET: Chitietkhenthuongs/Create
        public ActionResult Create()
        {
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong");
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten");
            return View();
        }

        // POST: Chitietkhenthuongs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Machitietkhenthuong,Manv,Makhenthuong,Lydokhenthuong,Tienthuong")] Chitietkhenthuong chitietkhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Chitietkhenthuongs.Add(chitietkhenthuong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong", chitietkhenthuong.Makhenthuong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkhenthuong.Manv);
            return View(chitietkhenthuong);
        }

        // GET: Chitietkhenthuongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong", chitietkhenthuong.Makhenthuong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkhenthuong.Manv);
            return View(chitietkhenthuong);
        }

        // POST: Chitietkhenthuongs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Machitietkhenthuong,Manv,Makhenthuong,Lydokhenthuong,Tienthuong")] Chitietkhenthuong chitietkhenthuong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitietkhenthuong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Makhenthuong = new SelectList(db.Khenthuongs, "Makhenthuong", "Tenkhenthuong", chitietkhenthuong.Makhenthuong);
            ViewBag.Manv = new SelectList(db.Thongtinnhansus, "Manv", "Hoten", chitietkhenthuong.Manv);
            return View(chitietkhenthuong);
        }

        // GET: Chitietkhenthuongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            if (chitietkhenthuong == null)
            {
                return HttpNotFound();
            }
            return View(chitietkhenthuong);
        }

        // POST: Chitietkhenthuongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chitietkhenthuong chitietkhenthuong = db.Chitietkhenthuongs.Find(id);
            db.Chitietkhenthuongs.Remove(chitietkhenthuong);
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
